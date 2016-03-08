using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public class NewAppUser
    {
        public string Name { get; set; }
        public bool IsGuestUser { get; set; }
    }
}
