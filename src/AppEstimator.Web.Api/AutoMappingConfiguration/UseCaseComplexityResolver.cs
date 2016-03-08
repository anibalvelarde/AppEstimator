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
    public class UseCaseComplexityResolver : ValueResolver<Data.Entities.UseCase, Models.Complexity>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override Models.Complexity ResolveCore(Data.Entities.UseCase source)
        {
            return AutoMapper.Map<Models.Complexity>(source.Complexity);
        }
    }
}
