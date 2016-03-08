using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class AppUser : IVersionedEntity
    {
        private readonly List<Estimate> _estimates = new List<Estimate>();

        public virtual long AppUserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string GitHubId { get; set; }
        public virtual bool IsGuestUser { get; set; }
        public virtual IList<Estimate> Estimates
        {
            get { return _estimates; }
        }
        public virtual byte[] Version { get; set; }

    }
}
