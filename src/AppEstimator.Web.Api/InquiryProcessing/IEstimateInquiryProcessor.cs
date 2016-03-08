using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.InquiryProcessing
{
    public interface IEstimateInquiryProcessor
    {
        Models.Estimate GetEstimateById(long estimateId);
        IList<Models.EstimateInfo> GetEstimateByUser(long userId);
    }
}
