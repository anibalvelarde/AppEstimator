using AppEstimator.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppEstimator.Web.Api.Models;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class NewEstimateToEstimateEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewEstimate, Data.Entities.Estimate>()
                .ForMember(opt => opt.EstimateId, x => x.Ignore())
                .ForMember(opt => opt.LastUpdatedOn, x => x.Ignore())
                .ForMember(opt => opt.Actors, x => x.Ignore())
                .ForMember(opt => opt.UseCases, x => x.Ignore())
                .ForMember(opt => opt.ECF, x => x.Ignore())
                .ForMember(opt => opt.TCF, x => x.Ignore())
                .ForMember(opt => opt.UAP, x => x.Ignore())
                .ForMember(opt => opt.UCP, x => x.Ignore())
                .ForMember(opt => opt.UUCP, x => x.Ignore())
                .ForMember(opt => opt.Effort, x => x.Ignore())
                .ForMember(opt => opt.HoursPerUCP, x => x.Ignore())
                .ForMember(opt => opt.Version, x => x.Ignore())
                .ForMember(opt => opt.EnvironmentalFactors, x => x.Ignore())
                .ForMember(opt => opt.TechnicalFactors, x => x.Ignore());
        }
    }
}