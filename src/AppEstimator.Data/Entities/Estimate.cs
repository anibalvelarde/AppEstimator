using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.Entities
{
    public class Estimate : IVersionedEntity
    {
        private readonly IList<EFValue> _environmentalFactors = new List<EFValue>();
        private readonly IList<TFValue> _technicalFactors = new List<TFValue>();
        private readonly IList<Actor> _actors = new List<Actor>();
        private readonly IList<UseCase> _useCases = new List<UseCase>();

        public virtual long EstimateId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual IList<EFValue> EnvironmentalFactors
        {
            get { return _environmentalFactors; }
        }
        public virtual IList<TFValue> TechnicalFactors
        {
            get { return _technicalFactors; }
        }
        public virtual IList<Actor> Actors
        {
            get { return _actors; }
        }
        public virtual IList<UseCase> UseCases
        {
            get { return _useCases; }
        }
        public virtual DateTime CreatedOnUtc { get; set; }
        public virtual DateTime? LastUpdatedOn { get; set; }
        public virtual string ProjectName { get; set; }
        /// <summary>
        /// Technical Complexity Factor
        /// </summary>
        public virtual decimal? TCF { get; set; }
        /// <summary>
        /// Environmental Complexity Factor
        /// </summary>
        public virtual decimal? ECF { get; set; }
        /// <summary>
        /// Unadjusted Actor Points
        /// </summary>
        public virtual decimal? UAP { get; set; }
        /// <summary>
        /// Unadjusted Use Case Points 
        /// </summary>
        public virtual decimal? UUCP { get; set; }
        /// <summary>
        /// Use Case Points
        /// </summary>
        public virtual decimal? UCP { get; set; }
        public virtual decimal Effort { get; set; }
        /// <summary>
        /// Hours of Effort per Use Case Point
        /// </summary>
        public virtual int HoursPerUCP { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
