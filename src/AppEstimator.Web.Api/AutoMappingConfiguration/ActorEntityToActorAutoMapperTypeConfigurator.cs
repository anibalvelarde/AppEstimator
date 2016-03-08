using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class ActorEntityToActorAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Actor, Models.Actor>()
                .ForMember(opt => opt.Complexity, x => x.ResolveUsing<ActorComplexityResolver>())
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}