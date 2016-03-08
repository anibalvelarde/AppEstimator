using AppEstimator.Common;
using AppEstimator.Web.Api.MaintenanceProcessing;
using AppEstimator.Web.Common;
using AppEstimator.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppEstimator.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("estimates")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.User)]
    public class EstimateChildObjectsController : ApiController
    {
        private readonly IEstimateUpdateMaintenanceProcessor _maintenanceProcessor;

        public EstimateChildObjectsController(IEstimateUpdateMaintenanceProcessor processor)
        {
            _maintenanceProcessor = processor;
        }

        [Route("{estimateId:long}/actors", Name = "AddEstimateActorRoute")]
        [HttpPost]
        public Models.Estimate AddEstimateActor(long estimateId, Models.Actor newActor)
        {
            var estimate = _maintenanceProcessor.AddActor(estimateId, newActor);
            return estimate;
        }
        
        [Route("{estimateId:long}/actors", Name = "DeleteEstimateActorsRoute")]
        [HttpDelete]
        public Models.Estimate DeleteEstimateActors(long estimateId)
        {
            var estimate = _maintenanceProcessor.DeleteAllActors(estimateId);
            return estimate;
        }

        [Route("{estimateId:long}/actors/{actorId:long}", Name = "DeleteEstimateActorRoute")]
        [HttpDelete]
        public Models.Estimate DeleteEstimateActor(long estimateId, long actorId)
        {
            var estimate = _maintenanceProcessor.DeleteActor(estimateId, actorId);
            return estimate;
        }

        [Route("{estimateId:long}/usecases", Name = "AddEstimateUseCaseRoute")]
        [HttpPost]
        public Models.Estimate AddEstimateUseCase(long estimateId, Models.UseCase newUseCase)
        {
            var estimate = _maintenanceProcessor.AddUseCase(estimateId, newUseCase);
            return estimate;
        }

        [Route("{estimateId:long}/usecases", Name = "DeleteEstimateUseCasesRoute")]
        [HttpDelete]
        public Models.Estimate DeleteEstimateUseCases(long estimateId)
        {
            var estimate = _maintenanceProcessor.DeleteAllUseCases(estimateId);
            return estimate;
        }

        [Route("{estimateId:long}/usecases/{useCaseId:long}", Name = "DeleteEstimateUseCaseRoute")]
        [HttpDelete]
        public Models.Estimate DeleteEstimateUseCase(long estimateId, long useCaseId)
        {
            var estimate = _maintenanceProcessor.DeleteUseCase(estimateId, useCaseId);
            return estimate;
        }

        [Route("{estimateId:long}/factors", Name = "InitializeFactorsRoute")]
        [HttpPut]
        public Models.Estimate InitializeFactors(long estimateId)
        {
            var estimate = _maintenanceProcessor.InitializeFactors(estimateId);
            return estimate;
        }

    }
}