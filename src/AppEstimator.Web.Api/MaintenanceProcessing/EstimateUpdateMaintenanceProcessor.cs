using AppEstimator.Common;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Data.QueryProcessors;
using AppEstimator.Web.Api.Calculators;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public class EstimateUpdateMaintenanceProcessor : IEstimateUpdateMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateEstimateQueryProcessor _queryProcessor;
        private readonly IUseCasePointCalculatorService _ucpCalcService;

        public EstimateUpdateMaintenanceProcessor(IUpdateEstimateQueryProcessor queryProcessor, IAutoMapper autoMapper, 
                                                  IUseCasePointCalculatorService calc)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _ucpCalcService = calc;
        }

        public Models.Estimate DeleteAllActors(long estimateId)
        {
            var estimateEntity = _queryProcessor.DeleteAllActors(estimateId);
            var estimateModel = this.CreateEstimateModelResponse(estimateEntity);
            _ucpCalcService.ComputeUseCasePoints(estimateModel);
            return estimateModel;
        }

        public Models.Estimate DeleteActor(long estimateId, long actorId)
        {
            var estimateEntity = _queryProcessor.DeleteActor(estimateId, actorId);
            var estimateModel = this.CreateEstimateModelResponse(estimateEntity);
            _ucpCalcService.ComputeUseCasePoints(estimateModel);
            return estimateModel;
        }

        public Models.Estimate DeleteAllUseCases(long estimateId)
        {
            var estimateEntity = _queryProcessor.DeleteAllUseCases(estimateId);
            var estimateModel = this.CreateEstimateModelResponse(estimateEntity);
            _ucpCalcService.ComputeUseCasePoints(estimateModel);
            return estimateModel;
        }

        public Models.Estimate DeleteUseCase(long estimateId, long useCaseId)
        {
            var estimateEntity = _queryProcessor.DeleteUseCase(estimateId, useCaseId);
            var estimateModel = this.CreateEstimateModelResponse(estimateEntity);
            _ucpCalcService.ComputeUseCasePoints(estimateModel);
            return estimateModel;
        }

        public Models.Estimate InitializeFactors(long estimateId)
        {
            var estimateEntity = _queryProcessor.InitializeFactors(estimateId);
            return this.CreateEstimateModelResponse(estimateEntity);
        }
       
        public Models.Estimate AddActor(long estimateId, Models.Actor newActor)
        {
            var actorEntity = _autoMapper.Map<Data.Entities.Actor>(newActor);

            var estimateEntity = _queryProcessor.AddActor(estimateId, actorEntity);

            var estimateModel = _autoMapper.Map<Models.Estimate>(estimateEntity);

            _ucpCalcService.ComputeUseCasePoints(estimateModel);

            // TODO: Implement link service
            estimateModel.AddLink(new Link
            {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:9555/api/v1/estimates/" + estimateModel.EstimateId,
                Rel = Constants.CommonLinkRelvalues.Self
            });

            return estimateModel;
        }

        public Models.Estimate AddUseCase(long estimateId, Models.UseCase newUseCase)
        {
            var useCaseEntity = _autoMapper.Map<Data.Entities.UseCase>(newUseCase);

            var estimateEntity = _queryProcessor.AddUseCase(estimateId, useCaseEntity);

            var estimateModel = _autoMapper.Map<Models.Estimate>(estimateEntity);

            _ucpCalcService.ComputeUseCasePoints(estimateModel);

            // TODO: Implement link service
            estimateModel.AddLink(new Link
            {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:9555/api/v1/estimates/" + estimateModel.EstimateId,
                Rel = Constants.CommonLinkRelvalues.Self
            });

            return estimateModel;
        }

        private Models.Estimate CreateEstimateModelResponse(Data.Entities.Estimate estimateEntity)
        {
            var estimate = _autoMapper.Map<Models.Estimate>(estimateEntity);
            return estimate;
        }
    }
}