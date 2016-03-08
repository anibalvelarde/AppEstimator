using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstimator.Web.Api.InquiryProcessing
{
    public interface IUserInquiryProcessor
    {
        Models.AppUser GetUserById(long userId);
        IList<Models.AppUser> GetUsersByName(string userName); 
        IList<Models.AppUserInfo> GetUsers();
    }
}
