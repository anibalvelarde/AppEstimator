using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class TFValueMap : VersionedClassMap<TFValue>
    {
        public TFValueMap()
        {
            Id(x => x.EstimateTechnicalFactorId).GeneratedBy.Identity();
            Map(x => x.Value)
                .Column("FactorValue")
                .Default("0")
                .Not.Nullable();
            References(x => x.Factor, "TechnicalFactorId");
            References(x => x.Estimate, "EstimateId");
            Table("EstimateTechnicalFactor");
        }
    }
}
