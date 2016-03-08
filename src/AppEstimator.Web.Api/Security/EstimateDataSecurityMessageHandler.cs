using AppEstimator.Common.Logging;
using AppEstimator.Common.Security;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Security
{
    public class EstimateDataSecurityMessageHandler : DelegatingHandler
    {
        private readonly ILog _logger;
        private readonly IUserSession _userSession;

        public EstimateDataSecurityMessageHandler(ILogManager logManager, IUserSession userSession)
        {
            _logger = logManager.GetLog(typeof(EstimateDataSecurityMessageHandler));
            _userSession = userSession;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if(this.CanHandleResponse(response))
            {
                this.ApplySecurityToResponseData((ObjectContent)response.Content);
            }

            return response;
        }

        /// <summary>
        /// Sets whether or not Web Api will serialize the data for Actors and Use Cases (the Specifications) associated to the Estimate.
        /// If the caller is not the owner of the Estimate, the data about the Actors and Use Cases will not be serialized
        /// in the response that gets back to the API caller. This is done to protect the nature and part if the Intellectual
        /// Property that may be contained in the list of actors and use cases involved in the calculations.
        /// </summary>
        /// <param name="objectContent"></param>
        private void ApplySecurityToResponseData(ObjectContent objectContent)
        {
            if(_userSession.Username.Equals(((Models.Estimate)objectContent.Value).User.Name))
            {
                // the caller user is the owner of the estimate... Serialize Actors or Use Cases and allow caller to see...
                ((Models.Estimate)objectContent.Value).SerializeSpecifications();
            }
            else
            {
                // the caller user is not the owner of the estimate... Do not serialize Actors or Use Cases...
                ((Models.Estimate)objectContent.Value).DoNotSerializeSpecifications();
            }
        }

        /// <summary>
        /// Verify if the object type in the response.Content is of the Models.Estimate type
        /// </summary>
        /// <param name="response">An HTTP response instance.</param>
        /// <returns>True, if the type of Response.Content = models.Estimate. False, if otherwise.</returns>
        private bool CanHandleResponse(HttpResponseMessage response)
        {
            var objectContent = response.Content as ObjectContent;
            var canHandleResponse = objectContent != null && objectContent.ObjectType == typeof(Models.Estimate);
            return canHandleResponse;
        }
    }
}