using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EFValueEntityToEFValueAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.EFValue, Models.EFValue>()
                .ForMember(opt => opt.EnvironmentalFactorInfo, x => x.ResolveUsing<EFValueEFInfoResolver>())
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}