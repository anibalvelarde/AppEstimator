using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.LinkServices
{
    public interface IAppUserLinkService
    {
        void AddSelfLink(AppUser user);
        void AddEstimatesLink(AppUser user);
        void AddSelfLink(AppUserInfo user);
    }
}
