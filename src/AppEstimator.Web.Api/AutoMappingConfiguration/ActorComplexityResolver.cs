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
    public class ActorComplexityResolver : ValueResolver<Data.Entities.Actor, Models.Complexity>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override Models.Complexity ResolveCore(Data.Entities.Actor source)
        {
            return AutoMapper.Map<Models.Complexity>(source.Complexity);
        }
    }
}
