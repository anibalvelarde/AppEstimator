using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class TechnicalFactor : IVersionedEntity
    {
        public virtual long TechnicalFactorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Multiplier { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
