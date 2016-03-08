using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.EntityViews
{
    public class EstimateInfo
    {
        public virtual long EstimateId { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual DateTime LastUpdatedOn { get; set; }
    }
}
