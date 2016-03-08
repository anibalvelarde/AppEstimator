using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Common;
using AppEstimator;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateUserResolver : ValueResolver<Data.Entities.Estimate, Models.AppUser>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override Models.AppUser ResolveCore(Data.Entities.Estimate source)
        {
            return AutoMapper.Map<Models.AppUser>(source.User);
        }
    }
}
