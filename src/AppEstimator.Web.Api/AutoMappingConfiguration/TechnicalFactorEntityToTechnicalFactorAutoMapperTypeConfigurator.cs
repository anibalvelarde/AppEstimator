using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class TechnicalFactorEntityToTechnicalFactorAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.TechnicalFactor, Models.TFInfo>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}