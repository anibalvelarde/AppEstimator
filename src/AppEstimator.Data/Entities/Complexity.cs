using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class Complexity : IVersionedEntity
    {
        public virtual long ComplexityId { get; set; }
        public virtual string Name { get; set; }
        public virtual char Type { get; set; }
        public virtual int Value { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
