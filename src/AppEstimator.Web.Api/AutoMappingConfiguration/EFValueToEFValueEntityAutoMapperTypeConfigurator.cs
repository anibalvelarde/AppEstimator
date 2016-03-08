using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EFValueToEFValueEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {

        public void Configure()
        {
            Mapper.CreateMap<Models.EFValue, Data.Entities.EFValue>()
                .ForMember(opt => opt.EstimateEnvironmentalFactorId, x => x.Ignore())
                .ForMember(opt => opt.Factor, x => x.ResolveUsing(typeof(EFValueEFInfoResolver)))
                .ForMember(opt => opt.Estimate, x => x.Ignore())
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}