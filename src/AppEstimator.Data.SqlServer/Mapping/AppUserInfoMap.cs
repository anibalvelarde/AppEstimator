using AppEstimator.Data.EntityViews;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class AppUserInfoMap : ClassMap<AppUserInfo>
    {
        public AppUserInfoMap()
        {
            Table("AppUserInfo");
            ReadOnly();
            Id(x => x.AppUserId);
            Map(x => x.Name);
            Map(x => x.IsGuestUser);
            Map(x => x.EstimateCount);
        }
    }
}
