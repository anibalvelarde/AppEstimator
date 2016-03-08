using AppEstimator.Common;
using AppEstimator.Web.Api.Models;
using AppEstimator.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.LinkServices
{
    public class CommonLinkService : ICommonLinkService
    {
        private IWebUserSession _userSession;

        public CommonLinkService(IWebUserSession userSession)
        {
            _userSession = userSession;
        }
        
        public void AddPageLinks(object linkContainer, string currentPageQueryString, string previousPageQueryString, string nextPageQueryString)
        {
            // TODO: need to create the IPageLinkContaining interface and use it as the type
            //       of the first paramter, linkContainer.
            throw new NotImplementedException();
        }

        public Models.Link GetLink(string pathFragment, string relValue, System.Net.Http.HttpMethod httpMethod)
        {
            const string delimitedVersionedApiRouteBaseFormatString =
                Constants.CommonRoutingDefinitions.ApiSegmentName + "/{0}/";

            var path = string.Concat(string.Format(delimitedVersionedApiRouteBaseFormatString,
                                                    _userSession.ApiVersionInUse), pathFragment);

            var uriBuilder = new UriBuilder
            {
                Scheme = _userSession.RequestUri.Scheme,
                Host = _userSession.RequestUri.Host,
                Port = _userSession.RequestUri.Port,
                Path = path
            };

            var link = new Link
            {
                Href = uriBuilder.Uri.AbsoluteUri,
                Rel = relValue,
                Method = httpMethod.Method
            };

            return link;
        }
    }
}