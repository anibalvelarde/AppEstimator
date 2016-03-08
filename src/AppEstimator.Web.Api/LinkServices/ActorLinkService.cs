using AppEstimator.Common;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.LinkServices
{
    public class ActorLinkService : IActorLinkService
    {
        private readonly ICommonLinkService _linkService;

        public ActorLinkService(ICommonLinkService linkService)
        {
            _linkService = linkService;
        }

        public void AddSelfLink(Models.Actor actor)
        {
            actor.AddLink(this.GetSelfLink(actor));
        }

        private Link GetSelfLink(Models.Actor actor)
        {
            var pathFragment = string.Format("users/{0}", actor.ActorId);
            var link = _linkService.GetLink(pathFragment, Constants.CommonLinkRelvalues.Self,
                                            HttpMethod.Get);
            return link;
        }
    }
}