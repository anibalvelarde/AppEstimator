using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public interface IContainLinks
    {
        List<Link> Links { get; set; }
        void AddLink(Link link);
    }
}
