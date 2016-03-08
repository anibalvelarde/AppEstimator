using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class EnvironmentalFactor : IVersionedEntity
    {
        public virtual long EnvironmentalFactorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Multiplier { get; set; }
        public virtual byte[] Version { get; set; }
    }

}
