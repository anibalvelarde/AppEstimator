using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class UseCaseEntityToUseCaseAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.UseCase, Models.UseCase>()
                .ForMember(opt => opt.Complexity, x => x.ResolveUsing<UseCaseComplexityResolver>())
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}