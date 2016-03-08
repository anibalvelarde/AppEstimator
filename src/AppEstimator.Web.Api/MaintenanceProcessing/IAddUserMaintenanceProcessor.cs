using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.MaintenanceProcessing
{
    public interface IAddUserMaintenanceProcessor
    {
        Models.AppUser AddUser(Models.NewAppUser newUser);
    }
}
