using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class EnvironmentalFactorMap : VersionedClassMap<EnvironmentalFactor>
    {
        public EnvironmentalFactorMap()
        {
            Id(x => x.EnvironmentalFactorId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            Map(x => x.Multiplier).Not.Nullable();
        }
    }
}
