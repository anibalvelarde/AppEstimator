using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Data.QueryProcessors
{
    public interface IUserFetcherQueryProcessor
    {
        Entities.AppUser GetUserById(long userId);
        IList<Entities.AppUser> GetUsersByName(string userName);
        IList<EntityViews.AppUserInfo> GetUsers();
    }
}
