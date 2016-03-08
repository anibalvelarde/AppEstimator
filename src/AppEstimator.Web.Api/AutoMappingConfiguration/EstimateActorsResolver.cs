using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Common;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateActorsResolver : ValueResolver<Data.Entities.Estimate, List<Models.Actor>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<Models.Actor> ResolveCore(Data.Entities.Estimate source)
        {
            return source.Actors.Select(x => AutoMapper.Map<Models.Actor>(x)).ToList();
        }
    }
}