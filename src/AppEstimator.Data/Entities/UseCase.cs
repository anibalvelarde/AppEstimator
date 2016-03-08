using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class UseCase : IVersionedEntity
    {
        public virtual long UseCaseId { get; set; }
        public virtual Estimate Estimate { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Complexity Complexity { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
