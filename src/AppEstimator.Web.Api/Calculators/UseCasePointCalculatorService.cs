using AppEstimator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEstimator.Web.Api.Calculators
{
    public class UseCasePointCalculatorService : IUseCasePointCalculatorService
    {
        public void ComputeUseCasePoints(Models.Estimate estimate)
        {
            // calculate Actor Points...
            estimate.UAP = this.CalculateActorWeighting(estimate.Actors);
            // calculate Use Case Points...
            estimate.UUCP = this.CalculateUnadjustedUseCasePoints(estimate.UseCases);
            // calculate Environmental Complexity Factors Ajustment...
            estimate.ECF = this.CalculateEnvironmentalComplexity(estimate.EnvironmentalFactors);
            // calculate Technical Complexity Factors Adjustment...
            estimate.TCF = this.CalculateTechnicalComplexity(estimate.TechnicalFactors);
            // calculate Use Case Points & Duration
            estimate.UCP = ((estimate.UAP + estimate.UUCP) * estimate.ECF * estimate.TCF);
            // determine the hours per use case point
            estimate.HoursPerUCP = this.DetermineHoursPerUseCasePoint(estimate.HoursPerUCP);
            // calculate the total effort...
            estimate.Effort = (estimate.UCP.Value * estimate.HoursPerUCP);
        }

        private int DetermineHoursPerUseCasePoint(int currentHoursPerUCP)
        {
            int max = Constants.UseCasePointAnalysisTheoryConstants.MaxHoursPerUseCasePoint;
            int min = Constants.UseCasePointAnalysisTheoryConstants.MinHoursPerUseCasePoint;
            int hours = 0;
            if(currentHoursPerUCP.Equals(0))
            {
                // if hours per use case point have not been defined, then average the default max and min
                hours = (min + max) / 2;
            }
            else
            {
                hours = currentHoursPerUCP;
            }

            return hours;
        }

        private decimal CalculateTechnicalComplexity(List<Models.TFValue> tecFacList)
        {
            decimal baseLine = Constants.UseCasePointAnalysisTheoryConstants.TechnicalComplexityBaseLine;
            decimal tfc = 0; decimal sumTcf = 0;

            foreach (var tf in tecFacList)
            {
                sumTcf += tf.Value;
            }

            tfc = baseLine + (sumTcf / 100);

            return tfc;
        }

        private decimal CalculateEnvironmentalComplexity(List<Models.EFValue> envFacList)
        {
            decimal baseLine = Constants.UseCasePointAnalysisTheoryConstants.EnvironmentalComplexityBaseLine;
            decimal baseMagnitude = Constants.UseCasePointAnalysisTheoryConstants.EnvironmentalComplexityMagnitude;
            decimal efc = 0; decimal sumEf = 0;

            foreach (var ef in envFacList)
            {
                sumEf += ef.Value;
            }

            efc = baseLine - (baseMagnitude * sumEf);

            return efc;
        }

        private decimal CalculateUnadjustedUseCasePoints(List<Models.UseCase> useCaseList)
        {
            decimal uucp = 0;
            foreach (var useCase in useCaseList)
            {
                uucp += useCase.Complexity.Value;
            }
            return uucp;
        }

        private decimal CalculateActorWeighting(List<Models.Actor> actorList)
        {
            decimal aw = 0;
            foreach (var actor in actorList)
            {
                aw += actor.Complexity.Value;
            }
            return aw;
        }
    }
}