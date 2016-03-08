using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class TechnicalFactorToTechnicalFactorEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {

        public void Configure()
        {
            Mapper.CreateMap<Models.TFInfo, Data.Entities.TechnicalFactor>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}