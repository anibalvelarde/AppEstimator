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
    public class EFValueEFInfoResolver : ValueResolver<Data.Entities.EFValue, Models.EFInfo>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override Models.EFInfo ResolveCore(Data.Entities.EFValue source)
        {
            return AutoMapper.Map<Models.EFInfo>(source.Factor);
        }
    }
}
