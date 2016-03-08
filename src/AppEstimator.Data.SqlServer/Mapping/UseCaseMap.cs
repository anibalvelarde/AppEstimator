using AppEstimator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.Mapping
{
    public class UseCaseMap : VersionedClassMap<UseCase>
    {
        public UseCaseMap()
        {
            Id(x => x.UseCaseId);
            Map(x => x.Title).Not.Nullable();
            Map(x => x.Description).Not.Nullable();

            References(x => x.Complexity, "ComplexityId");
            References(x => x.Estimate, "EstimateId");
        }
    }
}
