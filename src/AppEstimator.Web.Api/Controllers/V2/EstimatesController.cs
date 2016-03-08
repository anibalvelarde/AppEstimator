using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppEstimator.Web.Api.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/estimates")]
    public class EstimatesController : ApiController
    {
        [Route("", Name = "AddEstimateRouteV2")]
        [HttpPost]
        public Estimate AddEstimate(HttpRequestMessage requestMessage, Estimate newEstimate)
        {
            return new Estimate()
            {
                ProjectName = string.Format("In v2, newEstimate.ProjectName = {0}", newEstimate.ProjectName),
                CreatedOnUTC = newEstimate.CreatedOnUTC,
                User = newEstimate.User
            };
        }
    }
}
