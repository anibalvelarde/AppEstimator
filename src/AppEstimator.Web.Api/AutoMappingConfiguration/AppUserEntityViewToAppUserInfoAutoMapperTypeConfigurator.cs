﻿using AppEstimator.Common.TypeMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class AppUserEntityViewToAppUserInfoAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.EntityViews.AppUserInfo, Models.AppUserInfo>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}