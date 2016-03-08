using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppEstimator;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Common;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateEFValueResolver : ValueResolver<Data.Entities.Estimate, List<Models.EFValue>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<Models.EFValue> ResolveCore(Data.Entities.Estimate source)
        {
            return source.EnvironmentalFactors.Select(x => AutoMapper.Map<Models.EFValue>(x)).ToList();
        }
    }
}