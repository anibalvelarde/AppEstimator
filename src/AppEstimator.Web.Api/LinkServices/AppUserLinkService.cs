using AppEstimator.Common;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.LinkServices
{
    public class AppUserLinkService : IAppUserLinkService
    {
        private readonly ICommonLinkService _linkService;

        public AppUserLinkService(ICommonLinkService linkService)
        {
            _linkService = linkService;
        }

        public void AddSelfLink(Models.AppUser user)
        {
            user.AddLink(this.GetGenericSelfLink(user.AppUserId));
        }

        public void AddEstimatesLink(Models.AppUser user)
        {
            user.AddLink(this.GetEstimatesLink(user));
        }

        public void AddSelfLink(Models.AppUserInfo user)
        {
            user.AddLink(this.GetGenericSelfLink(user.AppUserId));
        }

        private Link GetEstimatesLink(AppUser user)
        {
            var pathFragment = string.Format("estimates");
            var link = _linkService.GetLink(pathFragment, Constants.CommonLinkRelvalues.All, HttpMethod.Get);
            return link;
        }

        private Link GetGenericSelfLink(long id)
        {
            var pathFragment = string.Format("users/{0}", id);
            var link = _linkService.GetLink(pathFragment, Constants.CommonLinkRelvalues.Self,
                                            HttpMethod.Get);
            return link;
        }
    }
}