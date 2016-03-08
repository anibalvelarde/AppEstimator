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
    public class TFValueTFInfoResolver : ValueResolver<Data.Entities.TFValue, Models.TFInfo>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override Models.TFInfo ResolveCore(Data.Entities.TFValue source)
        {
            return AutoMapper.Map<Models.TFInfo>(source.Factor);
        }
    }
}
