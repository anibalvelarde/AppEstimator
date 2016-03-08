using AppEstimator.Data.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class AppUserMap : VersionedClassMap<AppUser>
    {
        public AppUserMap()
        {
            Id(x => x.AppUserId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.GitHubId).Not.Nullable();
            Map(x => x.IsGuestUser).Not.Nullable();

            HasMany(x => x.Estimates)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore);
        }
    }
}
