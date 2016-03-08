using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.QueryProcessors
{
    public interface IEstimateFetcherQueryProcessor
    {
        Entities.Estimate GetEstimateById(long estimateId);
        IList<Entities.Estimate> GetEstimates(long userId);
    }
}
