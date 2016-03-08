using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.QueryProcessors
{
    public interface IUpdateEstimateQueryProcessor
    {

        Data.Entities.Estimate AddActor(long estimateId, Data.Entities.Actor actor);
        Data.Entities.Estimate DeleteAllActors(long estimateId);
        Data.Entities.Estimate DeleteActor(long estimateId, long actorId);
        Data.Entities.Estimate AddUseCase(long estimateId, Data.Entities.UseCase useCase);
        Data.Entities.Estimate DeleteAllUseCases(long estimateId);
        Data.Entities.Estimate DeleteUseCase(long estimateId, long useCaseId);
        Data.Entities.Estimate InitializeFactors(long estimateId);        
    }
}
