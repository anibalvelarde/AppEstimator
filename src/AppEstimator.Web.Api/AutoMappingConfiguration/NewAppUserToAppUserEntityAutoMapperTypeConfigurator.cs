using AppEstimator.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppEstimator.Web.Api.Models;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class NewAppUserToAppUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewAppUser, Data.Entities.AppUser>()
                .ForMember(opt => opt.AppUserId, x => x.Ignore())
                .ForMember(opt => opt.GitHubId, x => x.Ignore())
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}