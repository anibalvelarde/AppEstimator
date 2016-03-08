using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.Models
{
    public class Estimate : IContainLinks
    {
        private List<Link> _links;
        private bool _shouldSerializeSpecs;

        public Estimate()
        {
        }

        public long EstimateId { get; set; }
        public AppUser User { get; set; }
        public List<EFValue> EnvironmentalFactors { get; set; }
        public List<TFValue> TechnicalFactors { get; set; }
        public List<Actor> Actors { get; set; }
        public List<UseCase> UseCases { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string ProjectName { get; set; }
        /// <summary>
        /// Technical Complexity Factor
        /// </summary>
        public decimal? TCF { get; set; }
        /// <summary>
        /// Environmental Complexity Factor
        /// </summary>
        public decimal? ECF { get; set; }
        /// <summary>
        /// Unadjusted Actor Points
        /// </summary>
        public decimal? UAP { get; set; }
        /// <summary>
        /// Unadjusted Use Case Points 
        /// </summary>
        public decimal? UUCP { get; set; }
        /// <summary>
        /// Use Case Points
        /// </summary>
        public decimal? UCP { get; set; }
        public decimal Effort { get; set; }
        /// <summary>
        /// Hours of Effort per Use Case Point
        /// </summary>
        public int HoursPerUCP { get; set; }
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }
        public bool ShouldSerializeActors()
        { 
            return _shouldSerializeSpecs; 
        }
        public bool ShouldSerializeUseCases()
        { 
            return _shouldSerializeSpecs;
        }

        public void AddLink(Link link)
        {
            this.Links.Add(link);
        }
        public void SerializeSpecifications()
        {
            _shouldSerializeSpecs = true;
        }
        public void DoNotSerializeSpecifications()
        {
            _shouldSerializeSpecs = false;
        }
    }
}
