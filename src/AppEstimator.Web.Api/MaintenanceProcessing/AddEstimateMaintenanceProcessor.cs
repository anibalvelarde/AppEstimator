using AppEstimator.Common;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Data.QueryProcessors;
using AppEstimator.Web.Api.LinkServices;
using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public class AddEstimateMaintenanceProcessor : IAddEstimateMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddEstimateQueryProcessor _queryProcessor;
        private readonly IEstimateLinkService _estimateLinkService;

        public AddEstimateMaintenanceProcessor(IAddEstimateQueryProcessor queryProcessor, IAutoMapper autoMapper, IEstimateLinkService linkService)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
            _estimateLinkService = linkService;
        }

        public Models.Estimate AddEstimate(Models.NewEstimate newEstimate)
        {
            var estimateEntity = _autoMapper.Map<Data.Entities.Estimate>(newEstimate);

            _queryProcessor.AddEstimate(estimateEntity);

            var estimate = _autoMapper.Map<Models.Estimate>(estimateEntity);

            // TODO: Implement link service
            _estimateLinkService.AddSelfLink(estimate);
            _estimateLinkService.AddLinksToChildObjects(estimate);

            return estimate;
        }
    }
}