using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Calculators
{
    public interface IUseCasePointCalculatorService
    {
        void ComputeUseCasePoints(Models.Estimate estimate);
    }
}
