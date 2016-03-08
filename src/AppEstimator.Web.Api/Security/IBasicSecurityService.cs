using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Security
{
    public interface IBasicSecurityService
    {
        bool SetPrincipal(string userName, string password);
    }
}
