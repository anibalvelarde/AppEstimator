using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class TFValueEntityToTFValueAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.TFValue, Models.TFValue>()
                .ForMember(opt => opt.TechnicalFactorInfo, x => x.ResolveUsing<TFValueTFInfoResolver>())
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}