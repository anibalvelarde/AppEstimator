using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public interface IEstimateUpdateMaintenanceProcessor
    {
        Models.Estimate AddActor(long estimateId, Models.Actor actor);
        Models.Estimate DeleteAllActors(long estimateId);
        Models.Estimate DeleteActor(long estimateId, long actorId);
        Models.Estimate AddUseCase(long estimateId, Models.UseCase useCase);
        Models.Estimate DeleteAllUseCases(long estimateId);
        Models.Estimate DeleteUseCase(long estimateId, long useCaseId);
        Models.Estimate InitializeFactors(long estimateId);   
    }
}
