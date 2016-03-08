using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateInfoEntityToEstimateInfoAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Estimate, Models.EstimateInfo>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}