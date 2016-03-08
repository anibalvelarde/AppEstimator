using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EnvironmentalFactorToEnvironmentalFactorEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {

        public void Configure()
        {
            Mapper.CreateMap<Models.EFInfo, Data.Entities.EnvironmentalFactor>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}