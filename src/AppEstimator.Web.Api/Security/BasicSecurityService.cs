using AppEstimator.Common;
using AppEstimator.Common.Logging;
using AppEstimator.Data.Entities;
using AppEstimator.Web.Common;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace AppEstimator.Web.Api.Security
{
    public class BasicSecurityService : IBasicSecurityService
    {
        private readonly ILog _log;

        public BasicSecurityService(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(BasicSecurityService));
        }

        public virtual ISession Session
        {
            get { return WebContainerManager.Get<ISession>(); }
        }

        public bool SetPrincipal(string userName, string password)
        {
            var user = this.GetUser(userName);

            IPrincipal principal = null;
            if (user == null || (principal = GetPrincipal(user)) == null)
            {
                _log.DebugFormat("System could not validate user {0}.", userName);
                return false;
            }

            Thread.CurrentPrincipal = principal;
            if(HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }

            return true;
        }

        public virtual AppUser GetUser(string userName)
        {
            userName = userName.ToLowerInvariant();
            return Session.QueryOver<AppUser>().Where(x => x.Name == userName).SingleOrDefault();
        }

        public virtual IPrincipal GetPrincipal(AppUser user)
        {
            var identity = new GenericIdentity(user.Name, Constants.SchemeTypes.Basic);

            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Name));
            identity.AddClaim(new Claim(Constants.AppEstimatorClaimTypes.UserIdentifier, user.AppUserId.ToString()));

            var username = user.Name.ToLowerInvariant();
            switch (username)
            {
                case "anibalvelarde":
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.Administrator));
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.VipUser));
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.User));
                    break;
                case "anibalvip":
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.VipUser));
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.User));
                    break;
                case "anibaluser":
                    identity.AddClaim(new Claim(ClaimTypes.Role, Constants.RoleNames.User));
                    break;
                default:
                    return null;
            }

            return new ClaimsPrincipal(identity);
        }
    }
}