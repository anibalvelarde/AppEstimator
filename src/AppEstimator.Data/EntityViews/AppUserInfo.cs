using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.EntityViews
{
    public class AppUserInfo
    {
        public virtual long AppUserId { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsGuestUser { get; set; }
        public virtual int EstimateCount { get; set; }
    }
}
