using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class Actor : IVersionedEntity
    {
        public virtual long ActorId { get; set; }
        public virtual Estimate Estimate { get; set; }
        public virtual string Name { get; set; }
        public virtual Complexity Complexity { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
