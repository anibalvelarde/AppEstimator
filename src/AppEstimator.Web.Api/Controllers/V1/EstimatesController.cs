using AppEstimator.Common;
using AppEstimator.Web.Api.InquiryProcessing;
using AppEstimator.Web.Api.MaintenanceProcessing;
using AppEstimator.Web.Api.Models;
using AppEstimator.Web.Api.Security;
using AppEstimator.Web.Common;
using AppEstimator.Web.Common.Routing;
using AppEstimator.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppEstimator.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("estimates")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.User)]
    public class EstimatesController : ApiController
    {
        private readonly IAddEstimateMaintenanceProcessor _addEstimateMaintenanceProcessor;
        private readonly IEstimateInquiryProcessor _estimateIdInquiryProcessor;
        private readonly IWebUserSession _userSession;

        public EstimatesController(IAddEstimateMaintenanceProcessor addEstimateMaintenanceProcessor, 
            IEstimateInquiryProcessor estimateByIdInquiryProcessor, IWebUserSession userSession)
        {
            _addEstimateMaintenanceProcessor = addEstimateMaintenanceProcessor;
            _estimateIdInquiryProcessor = estimateByIdInquiryProcessor;
            _userSession = userSession;
        }

        [Route("", Name = "AddEstimateRoute")]
        [HttpPost]
        [UserAudit]
        [Authorize(Roles = Constants.RoleNames.VipUser)]
        public IHttpActionResult AddEstimate(HttpRequestMessage requestMessage, NewEstimate newEstimate)
        {
            var estimate = _addEstimateMaintenanceProcessor.AddEstimate(newEstimate);
            var result = new EstimateCreatedActionResult(requestMessage, estimate);
            return result;
        }

        [Route("{id:long}", Name = "GetEstimateRoute")]
        [UserAudit]
        public Estimate GetEstimate(long id)
        {
            var estimate = _estimateIdInquiryProcessor.GetEstimateById(id);
            return estimate;
        }

        [Route("", Name = "GetEstimatesForLoggedInUserRoute")]
        [HttpGet]
        [UserAudit]
        public IList<EstimateInfo> GetEstimatesForLoggedInUser()
        {
            var estimates = _estimateIdInquiryProcessor.GetEstimateByUser(_userSession.AppEstimatorUserId);
            return estimates;
        }

        [Route("", Name = "GetEstimatesForUserRoute")]
        [HttpGet]
        [UserAudit]
        public IList<EstimateInfo> GetEstimatesForUser(long userId)
        {
            var estimates = _estimateIdInquiryProcessor.GetEstimateByUser(userId);
            return estimates;
        }    
    }
}
