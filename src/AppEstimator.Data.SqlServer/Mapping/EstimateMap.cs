using AppEstimator.Data.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class EstimateMap : VersionedClassMap<Estimate>
    {
        public EstimateMap()
        {
            Id(x => x.EstimateId).GeneratedBy.Identity();
            Map(x => x.CreatedOnUtc).Not.Nullable();
            Map(x => x.ProjectName).Not.Nullable();
            Map(x => x.HoursPerUCP).Not.Nullable();

            Map(x => x.LastUpdatedOn).Nullable();
            Map(x => x.TCF).Nullable();
            Map(x => x.ECF).Nullable();
            Map(x => x.UAP).Nullable();
            Map(x => x.UUCP).Nullable();
            Map(x => x.UCP).Nullable();
            Map(x => x.Effort).Nullable();

            References(x => x.User, "UserId");

            HasMany(x => x.Actors)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .KeyColumn("EstimateId")
                .Cascade.All();
            HasMany(x => x.UseCases)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .KeyColumn("EstimateId")
                .Cascade.All();
            HasMany(x => x.TechnicalFactors)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .KeyColumn("EstimateId")
                .Cascade.All();
            HasMany(x => x.EnvironmentalFactors)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .KeyColumn("EstimateId")
                .Cascade.All();
        }
    }
}
