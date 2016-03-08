using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateTFValueResolver : ValueResolver<Data.Entities.Estimate, List<Models.TFValue>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<Models.TFValue> ResolveCore(Data.Entities.Estimate source)
        {
            return source.TechnicalFactors.Select(x => AutoMapper.Map<Models.TFValue>(x)).ToList();
        }
    }
}