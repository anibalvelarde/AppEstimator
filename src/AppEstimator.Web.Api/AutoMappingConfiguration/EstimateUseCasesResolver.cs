using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Common;

namespace AppEstimator.Web.Api.AutoMappingConfiguration
{
    public class EstimateUseCasesResolver : ValueResolver<Data.Entities.Estimate, List<Models.UseCase>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<Models.UseCase> ResolveCore(Data.Entities.Estimate source)
        {
            return source.UseCases.Select(x => AutoMapper.Map<Models.UseCase>(x)).ToList();
        }
    }
}