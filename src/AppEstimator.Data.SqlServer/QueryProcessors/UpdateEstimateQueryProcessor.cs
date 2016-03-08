using AppEstimator.Common;
using AppEstimator.Common.Security;
using AppEstimator.Data.Entities;
using AppEstimator.Data.Exceptions;
using AppEstimator.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.SqlServer.QueryProcessors
{
    public class UpdateEstimateQueryProcessor : IUpdateEstimateQueryProcessor
    {
        private readonly ISession _session;
        private readonly IDateTime _dateTime;

        public UpdateEstimateQueryProcessor(ISession session, IDateTime dateTime)
        {
            _session = session;
            _dateTime = dateTime;
        }        

        public Estimate DeleteAllActors(long estimateId)
        {
            var estimate = this.GetValidEstimate(estimateId);
            this.UpdateEstimateActors(estimate, null, false);
            _session.SaveOrUpdate(estimate);
            return estimate;
        }

        public Estimate DeleteActor(long estimateId, long actorId)
        {
            var estimate = this.GetValidEstimate(estimateId);
            var actor = estimate.Actors.FirstOrDefault(x => x.ActorId == actorId);
            if (actor != null)
            {
                estimate.Actors.Remove(actor);
                _session.SaveOrUpdate(estimate);
            }
            return estimate;
        }

        public Estimate DeleteAllUseCases(long estimateId)
        {
            var estimate = this.GetValidEstimate(estimateId);
            this.UpdateEstimateUseCases(estimate, null, false);
            _session.SaveOrUpdate(estimate);
            return estimate;
        }

        public Estimate DeleteUseCase(long estimateId, long useCaseId)
        {
            var estimate = this.GetValidEstimate(estimateId);
            var useCase = estimate.UseCases.FirstOrDefault(x => x.UseCaseId == useCaseId);
            if (useCaseId != 0)
            {
                estimate.UseCases.Remove(useCase);
                _session.SaveOrUpdate(estimate);
            }
            return estimate;
        }

        public Estimate InitializeFactors(long estimateId)
        {
            var estimate = this.GetValidEstimate(estimateId);
            if (estimate.EnvironmentalFactors.Count == 0)
            {
                this.AddEnvironmentalFactors(estimate);
            }
            else
            {
                this.ResetEnvironmentalFactors(estimate);
            }
            if (estimate.TechnicalFactors.Count == 0)
            {
                this.AddTechnicalFactors(estimate);
            }
            else
            {
                this.ResetTechnicalFactors(estimate);
            }
            _session.SaveOrUpdate(estimate);
            return estimate;
        }

        private void AddEnvironmentalFactors(Estimate estimate)
        {
            var envFactors = _session.QueryOver<EnvironmentalFactor>().List();

            if (envFactors != null)
            {
                foreach (var fac in envFactors)
                {
                    var aFactor = new EFValue() { Factor = fac, Value = 0 };
                    estimate.EnvironmentalFactors.Add(aFactor);
                    aFactor.Estimate = estimate;
                }
            }
        }

        private void AddTechnicalFactors(Estimate estimate)
        {
            var techFactors = _session.QueryOver<TechnicalFactor>().List();

            if (techFactors != null)
            {
                foreach (var fac in techFactors)
                {
                    var aFactor = new TFValue() { Factor = fac, Value = 0 };
                    estimate.TechnicalFactors.Add(aFactor);
                    aFactor.Estimate = estimate;
                }
            }
        }

        private void ResetEnvironmentalFactors(Estimate estimate)
        {
            estimate.EnvironmentalFactors.Clear();
            this.AddEnvironmentalFactors(estimate);
        }

        private void ResetTechnicalFactors(Estimate estimate)
        {
            estimate.TechnicalFactors.Clear();
            this.AddTechnicalFactors(estimate);
        }

        private Estimate GetValidEstimate(long estimateId)
        {
            var estimate = _session.Get<Estimate>(estimateId);
            if (estimate == null)
            {
                throw new RootObjectNotFoundException("Estimate not found");
            }
            return estimate;
        }

        private Actor GetValidActor(long actorId)
        {
            var actor = _session.Get<Actor>(actorId);
            if (actor == null)
            {
                throw new ChildObjectNotFoundException("Actor not found");
            }
            return actor;
        }

        private UseCase GetValidUseCase(long useCaseId)
        {
            var useCase = _session.Get<UseCase>(useCaseId);
            if (useCase == null)
            {
                throw new ChildObjectNotFoundException("Use Case not found");
            }
            return useCase;
        }

        private void UpdateEstimateActors(Estimate estimate, IEnumerable<long> actorIds, bool appendToExisting)
        {
            if (!appendToExisting)
            {
                estimate.Actors.Clear();
            }

            if (actorIds != null)
            {
                foreach (var actor in actorIds.Select(this.GetValidActor))
                {
                    if (!estimate.Actors.Contains(actor))
                    {
                        estimate.Actors.Add(actor);
                    }
                }
            }
        }

        private void UpdateEstimateUseCases(Estimate estimate, IEnumerable<long> useCaseIds, bool appendToExisting)
        {
            if (!appendToExisting)
            {
                estimate.UseCases.Clear();
            }

            if (useCaseIds != null)
            {
                foreach (var useCase in useCaseIds.Select(this.GetValidUseCase))
                {
                    if (!estimate.UseCases.Contains(useCase))
                    {
                        estimate.UseCases.Add(useCase);
                    }
                }
            }
        }

        public Estimate AddActor(long estimateId, Actor actor)
        {
            // fetch the estimate
            var estimate = this.GetValidEstimate(estimateId);
            // update attributes fo the Estimate upon addition of new Actor
            estimate.LastUpdatedOn = _dateTime.UtcNow;
            // ensure that the actor is not already contained in the Estimate
            if (!estimate.Actors.Contains(actor))
            {
                estimate.Actors.Add(actor);
                actor.Estimate = estimate;        
            }
            return estimate;
        }

        public Estimate AddUseCase(long estimateId, UseCase useCase)
        {
            // fetch the estimate
            var estimate = this.GetValidEstimate(estimateId);
            // update attributes fo the Estimate upon addition of new Use Case
            estimate.LastUpdatedOn = _dateTime.UtcNow;
            // ensure that the actor is not already contained in the Estimate
            if (!estimate.UseCases.Contains(useCase))
            {
                estimate.UseCases.Add(useCase);
                useCase.Estimate = estimate;
            }
            return estimate;
        }
    }
}
