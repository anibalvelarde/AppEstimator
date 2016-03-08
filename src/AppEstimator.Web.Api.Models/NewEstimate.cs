using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    /// <summary>
    /// This class exposes the minimum attributes required for properly setting up
    /// a brand new Estimate.
    /// </summary>
    public class NewEstimate
    {
        public string ProjectName { get; set; }
        public AppUser User { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
