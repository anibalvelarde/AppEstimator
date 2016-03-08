using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public class EFInfo
    {
        private List<Link> _links;

        public long EnvironmentalFactorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Multiplier { get; set; }
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
