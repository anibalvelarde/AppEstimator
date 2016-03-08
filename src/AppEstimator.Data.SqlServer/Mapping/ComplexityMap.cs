using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class ComplexityMap : VersionedClassMap<Complexity>
    {
        public ComplexityMap()
        {
            Id(x => x.ComplexityId);
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Value).Not.Nullable();
        }
    }
}
