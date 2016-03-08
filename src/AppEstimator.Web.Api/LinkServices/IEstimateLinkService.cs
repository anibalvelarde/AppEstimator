using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.LinkServices
{
    public interface IEstimateLinkService 
    {
        // for "real" estimates...
        Link GetAllEstimatesLink();
        void AddSelfLink(Models.Estimate estimate);
        void AddLinksToChildObjects(Models.Estimate estimate);
        // for "info" estimates...
        void AddSelfLink(Models.EstimateInfo estimate);
    }
}
