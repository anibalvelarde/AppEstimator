using AppEstimator.Common;
using AppEstimator.Common.Security;
using AppEstimator.Data.Entities;
using AppEstimator.Data.Exceptions;
using AppEstimator.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.QueryProcessors
{
    public class AddEstimateQueryProcessor : IAddEstimateQueryProcessor
    {
        private readonly ISession _session;
        private readonly IUserSession _userSession;
        private readonly IDateTime _dateTime;
        private readonly IUpdateEstimateQueryProcessor _updateEstimateQryProc; 

        public AddEstimateQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime,
                                         IUpdateEstimateQueryProcessor updateEstimateQryProc)
        {
            _session = session;
            _userSession = userSession;
            _dateTime = dateTime;
            _updateEstimateQryProc = updateEstimateQryProc;
        }

        public void AddEstimate(Estimate estimate)
        {
            AppUser persistedUser = null;
            // update attributes of the Estimate upon persistence of new Estimate
            estimate.CreatedOnUtc = _dateTime.UtcNow;
            estimate.LastUpdatedOn = _dateTime.UtcNow;
            // verify the user exists on database
            if(estimate.User != null)
            {
                persistedUser = _session.Get<AppUser>(estimate.User.AppUserId);
                if(persistedUser == null)
                {
                    throw new ChildObjectNotFoundException(string.Format("UserID {0} not found.", estimate.User.AppUserId));
                }
            }
            else
            {
                persistedUser = _session.QueryOver<AppUser>().Where(x => x.Name == _userSession.Username).SingleOrDefault();
                estimate.User = persistedUser;
            }
            // persist a new Estimate
            _session.SaveOrUpdate(estimate);
            estimate = _updateEstimateQryProc.InitializeFactors(estimate.EstimateId);
        }
    }
}
