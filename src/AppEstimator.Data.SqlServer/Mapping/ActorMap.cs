using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class ActorMap : VersionedClassMap<Actor>
    {
        public ActorMap()
        {
            Id(x => x.ActorId).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            References(x => x.Complexity, "ComplexityId");
            References(x => x.Estimate, "EstimateId");
        }
    }
}
