using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public class EstimateInfo : IContainLinks
    {
        private List<Link> _links;

        public EstimateInfo() { }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public long EstimateId { get; set; }
        public string ProjectName { get; set; }
        public DateTime LastUpdatedOn { get; set;}

        public void AddLink(Link link)
        {
            this.Links.Add(link);
        }
    }
}
