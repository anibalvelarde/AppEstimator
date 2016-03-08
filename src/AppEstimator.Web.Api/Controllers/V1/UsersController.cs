using AppEstimator.Common;
using AppEstimator.Web.Api.InquiryProcessing;
using AppEstimator.Web.Api.MaintenanceProcessing;
using AppEstimator.Web.Api.Security;
using AppEstimator.Web.Common;
using AppEstimator.Web.Common.Routing;
using AppEstimator.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppEstimator.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("users")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.User)]
    public class UsersController : ApiController
    {
        private readonly IWebUserSession _webUserSession;
        private readonly IUserInquiryProcessor _userInquiryProcessor;
        private readonly IAddUserMaintenanceProcessor _addUserMaintProc;


        public UsersController(IWebUserSession webUserSession, IUserInquiryProcessor userInquiryProcessor, IAddUserMaintenanceProcessor addMaintProc)
        {
            _webUserSession = webUserSession;
            _userInquiryProcessor = userInquiryProcessor;
            _addUserMaintProc = addMaintProc;
        }

        [Route("", Name = "GetUsersRoute")]
        [HttpGet]
        [UserAudit]
        public IList<Models.AppUserInfo> GetUsers()
        {
            var users = _userInquiryProcessor.GetUsers();
            return users;
        }

        [Route("{id:long}", Name = "GetUserRoute")]
        [HttpGet]
        [UserAudit]
        public Models.AppUser GetUser(long id)
        {
            var user = _userInquiryProcessor.GetUserById(id);
            return user;
        }

        [Route("", Name = "GetUserByNameRoute")]
        [HttpGet]
        [UserAudit]
        public IList<Models.AppUser> GetUserByName(string name)
        {
            var user = _userInquiryProcessor.GetUsersByName(name);
            return user;
        }

        [Route("", Name = "AddUserRoute")]
        [HttpPost] [UserAudit]
        public Models.AppUser AddUser(Models.NewAppUser newUser)
        {
            var addedUser = _addUserMaintProc.AddUser(newUser);
            return addedUser;
        }

    }
}