using AppEstimator.Common.TypeMapping;
using AppEstimator.Data.Exceptions;
using AppEstimator.Data.QueryProcessors;
using AppEstimator.Web.Api.Calculators;
using AppEstimator.Web.Api.LinkServices;
using AppEstimator.Web.Api.Models;
using AppEstimator.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.InquiryProcessing
{
    public class EstimateInquiryProcessor : IEstimateInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IEstimateFetcherQueryProcessor _queryProcessor;
        private readonly IWebUserSession _webUserSession;
        private readonly IEstimateLinkService _linkService;
        private readonly IUseCasePointCalculatorService _calculator;

        public EstimateInquiryProcessor(IAutoMapper autoMapper, IEstimateFetcherQueryProcessor queryProcessor,
                                        IEstimateLinkService linkService, IWebUserSession userSession,
                                        IUseCasePointCalculatorService calculator)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _webUserSession = userSession;
            _linkService = linkService;
            _calculator = calculator;
        }

        public Models.Estimate GetEstimateById(long estimateId)
        {
            var estimateEntity = _queryProcessor.GetEstimateById(estimateId);
            if(estimateEntity == null)
            {
                throw new RootObjectNotFoundException("Estimate not found");
            }

            var estimateModel = _autoMapper.Map<Models.Estimate>(estimateEntity);
            _calculator.ComputeUseCasePoints(estimateModel);
            this.ManageHttpLinks(estimateModel);
            return estimateModel;
        }

        public IList<Models.EstimateInfo> GetEstimateByUser(long userId)
        {
            var estimateEntities = _queryProcessor.GetEstimates(userId);
            if(estimateEntities == null)
            {
                throw new RootObjectNotFoundException("User has no estimates defined");
            }

            IList<EstimateInfo> estimateModels = new List<EstimateInfo>();
            foreach (var estimateEntity in estimateEntities)
            {
                var estimateModel = _autoMapper.Map<Models.EstimateInfo>(estimateEntity);
                this.ManageHttpLinks(estimateModel);
                estimateModels.Add(estimateModel);
            }
            return estimateModels;
        }

        private void ManageHttpLinks(Models.Estimate est)
        {
            _linkService.AddSelfLink(est);
            _linkService.AddLinksToChildObjects(est);
        }

        private void ManageHttpLinks(Models.EstimateInfo est)
        {
            _linkService.AddSelfLink(est);
        }
    }
}