using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class TFValueToTFValueEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {

        public void Configure()
        {
            Mapper.CreateMap<Models.TFValue, Data.Entities.TFValue>()
                .ForMember(opt => opt.EstimateTechnicalFactorId, x=> x.Ignore())
                .ForMember(opt => opt.Factor, x => x.ResolveUsing(typeof(TFValueTFInfoResolver)))
                .ForMember(opt => opt.Estimate, x => x.Ignore())
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}