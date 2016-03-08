using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class TFValue : IVersionedEntity
    {
        public virtual long EstimateTechnicalFactorId { get; set; }
        public virtual Estimate Estimate { get; set; }
        public virtual TechnicalFactor Factor { get; set; }
        public virtual long Value { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
