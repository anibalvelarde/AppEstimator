using AppEstimator.Common;
using AppEstimator.Common.Security;
using AppEstimator.Data.Entities;
using AppEstimator.Data.Exceptions;
using AppEstimator.Data.QueryProcessors;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.QueryProcessors
{
    public class AddUserQueryProcessor : IAddUserQueryProcessor
    {
        private readonly ISession _session; 

        public AddUserQueryProcessor(ISession session)
        {
            _session = session;
        }

        public AppUser AddUser(AppUser newUser)
        {
            if(!this.DoesUserAlreadyExist(newUser))
            {
                // set the Guid value
                newUser.GitHubId = Guid.NewGuid().ToString();
                // persist a new AppUser
                _session.SaveOrUpdate(newUser);
                return newUser;
            }
            else
            {
                var foundUser = _session.QueryOver<AppUser>()
                            .Where(new NHibernate.Criterion.LikeExpression("Name", newUser.Name))
                            .TransformUsing(Transformers.RootEntity)
                            .List<Entities.AppUser>()
                            .FirstOrDefault();
                return foundUser;
            }
        }

        private bool DoesUserAlreadyExist(AppUser newUser)
        {
            var persistedUser = _session.QueryOver<AppUser>()
                            .Where(new NHibernate.Criterion.LikeExpression("Name", newUser.Name));
            var rowCount = persistedUser.RowCount();
            if(rowCount > 1)
            {
                throw new DuplicateDataFoundException(string.Format("Multiple users with name '{0}' were found.", newUser.Name));
            }
            return (rowCount == 1);
        }
    }
}
