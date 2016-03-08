using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class AppUserInfoToAppUserEntityViewAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {

        public void Configure()
        {
            Mapper.CreateMap<Models.AppUserInfo, Data.EntityViews.AppUserInfo>();
        }
    }
}