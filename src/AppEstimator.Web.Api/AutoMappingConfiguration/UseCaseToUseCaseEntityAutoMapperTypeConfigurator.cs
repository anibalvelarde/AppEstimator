using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class UseCaseToUseCaseEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Models.UseCase, Data.Entities.UseCase>()
                .ForMember(opt => opt.Version, x => x.Ignore())
                .ForMember(opt => opt.Estimate, x => x.Ignore());
        }
    }
}