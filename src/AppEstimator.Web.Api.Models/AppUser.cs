using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public class AppUser : IContainLinks
    {
        private List<Link> _links;

        public long AppUserId { get; set; }
        public string Name { get; set; }
        public string GitHubId { get; set; }
        public bool IsGuestUser { get; set; }
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            this.Links.Add(link);
        }
    }
}
