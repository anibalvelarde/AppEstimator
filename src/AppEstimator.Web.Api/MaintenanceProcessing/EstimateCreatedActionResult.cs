using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public class EstimateCreatedActionResult : IHttpActionResult
    {
        private readonly Models.Estimate _createdEstimate;
        private readonly HttpRequestMessage _requestMessage;

        public EstimateCreatedActionResult(HttpRequestMessage requestMessage, Models.Estimate createdEstimate)
        {
            _createdEstimate = createdEstimate;
            _requestMessage = requestMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            var responseMessage = _requestMessage.CreateResponse(
                HttpStatusCode.Created, _createdEstimate);
            responseMessage.Headers.Location = LocationLinkCalculator.GetLocationLink(_createdEstimate);
            return responseMessage;
        }
    }
}