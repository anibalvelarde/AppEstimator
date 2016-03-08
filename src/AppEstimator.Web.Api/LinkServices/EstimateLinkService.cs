using AppEstimator.Common;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.LinkServices
{
    public class EstimateLinkService : IEstimateLinkService
    {
        private readonly ICommonLinkService _commonLinkService;
        private readonly IActorLinkService _actorLinkService;
        private readonly IUseCaseLinkService _useCaseLinkSerivce;

        public EstimateLinkService(ICommonLinkService commonLinkService, IActorLinkService actorLinkService,
                                    IUseCaseLinkService useCaseLinkService)
        {
            _commonLinkService = commonLinkService;
            _actorLinkService = actorLinkService;
            _useCaseLinkSerivce = useCaseLinkService;
        }

        public Models.Link GetAllEstimatesLink()
        {
            throw new NotImplementedException();
        }

        public void AddSelfLink(Models.Estimate estimate)
        {
            estimate.AddLink(this.GetSelfLink(estimate.EstimateId));
        }

        public void AddLinksToChildObjects(Models.Estimate estimate)
        {
            // for the Actors...
            estimate.Actors.ForEach(x => _actorLinkService.AddSelfLink(x));
            // for the Use Cases...
            estimate.UseCases.ForEach(x => _useCaseLinkSerivce.AddSelfLink(x));
        }

        private Link GetSelfLink(long estimateId)
        {
            var pathFragment = string.Format("estimates/{0}", estimateId);
            var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelvalues.Self,
                                            HttpMethod.Get);
            return link;
        }

        public void AddSelfLink(EstimateInfo estimate)
        {
            // In this case, we are getting an "info" version of the estimate, but
            // the HTTP link we want is to the "real" version of the estimate.
            // That's why we are calling the same "GetSelfLink(id)" that the 
            // AddSelf method calls for the real estimate.
            estimate.AddLink(this.GetSelfLink(estimate.EstimateId));
        }
    }
}