using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class EFValueMap : VersionedClassMap<EFValue>
    {
        public EFValueMap()
        {
            Id(x => x.EstimateEnvironmentalFactorId).GeneratedBy.Identity();
            Map(x => x.Value)
                .Column("FactorValue")
                .Default("0")
                .Not.Nullable();
            References(x => x.Factor, "EnvironmentalFactorId");
            References(x => x.Estimate, "EstimateId");
            Table("EstimateEnvironmentalFactor");
        }
    }
}
