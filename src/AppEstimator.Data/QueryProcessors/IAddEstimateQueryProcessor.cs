using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.QueryProcessors
{
    public interface IAddEstimateQueryProcessor
    {
        void AddEstimate(Estimate estimate);
    }
}
