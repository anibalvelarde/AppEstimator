
using AppEstimator.Common;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.LinkServices
{
    public class UseCaseLinkService : IUseCaseLinkService
    {
        private readonly ICommonLinkService _linkService;


        public UseCaseLinkService(ICommonLinkService linkService)
        {
            _linkService = linkService;
        }

        public void AddSelfLink(Models.UseCase useCase)
        {
            useCase.AddLink(this.GetSelfLink(useCase));
        }

        private Link GetSelfLink(Models.UseCase useCase)
        {
            var pathFragment = string.Format("usecases/{0}", useCase.UseCaseId);
            var link = _linkService.GetLink(pathFragment, Constants.CommonLinkRelvalues.Self,
                                            HttpMethod.Get);
            return link;
        }
    }
}