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
    public class EstimateFetcherQueryProcessor : IEstimateFetcherQueryProcessor
    {
        private readonly ISession _session;

        public EstimateFetcherQueryProcessor(ISession session)
        {
            _session = session;
        }

        public Entities.Estimate GetEstimateById(long estimateId)
        {
            var estimate = _session.Get<Entities.Estimate>(estimateId);
            return estimate;
        }

        public IList<Entities.Estimate> GetEstimates(long userId)
        {
            IList<Entities.Estimate> estimateList = _session.QueryOver<Entities.Estimate>()
                            .Where(e => e.User.AppUserId == userId)
                            .TransformUsing(Transformers.RootEntity)
                            .List<Entities.Estimate>();
            return estimateList;                                    
        }
    }
}
