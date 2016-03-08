using AppEstimator.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public interface IAddEstimateMaintenanceProcessor
    {
        Estimate AddEstimate(NewEstimate newEstimate);
    }
}
