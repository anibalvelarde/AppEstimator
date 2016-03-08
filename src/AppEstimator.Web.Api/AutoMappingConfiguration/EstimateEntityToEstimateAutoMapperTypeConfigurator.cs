using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateEntityToEstimateAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Estimate, Models.Estimate>()
                .ForMember(opt => opt.Links, x => x.Ignore())
                .ForMember(opt => opt.Actors, x => x.ResolveUsing<EstimateActorsResolver>())
                .ForMember(opt => opt.UseCases, x => x.ResolveUsing<EstimateUseCasesResolver>())
                .ForMember(opt => opt.User, x => x.ResolveUsing<EstimateUserResolver>())
                .ForMember(opt => opt.EnvironmentalFactors, x => x.ResolveUsing<EstimateEFValueResolver>())
                .ForMember(opt => opt.TechnicalFactors, x => x.ResolveUsing<EstimateTFValueResolver>())
;
        }
    }
}