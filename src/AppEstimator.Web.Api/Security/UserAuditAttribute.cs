using AppEstimator.Common.Logging;
using AppEstimator.Common.Security;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Threading;
using AppEstimator.Web.Common;

namespace AppEstimator.Web.Api.Security
{
    public class UserAuditAttribute : ActionFilterAttribute
    {
        private readonly ILog _log;
        private readonly IUserSession _userSession;

        public UserAuditAttribute()
            : this(WebContainerManager.Get<ILogManager>(), WebContainerManager.Get<IUserSession>())
        { }

        public UserAuditAttribute(ILogManager logManager, IUserSession userSession)
        {
            _log = logManager.GetLog(typeof(UserAuditAttribute));
            _userSession = userSession;
        }

        public override bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public override Task OnActionExecutingAsync(System.Web.Http.Controllers.HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            _log.Debug("Starting execution...");
            var userName = _userSession.Username;
            return Task.Run(()=> AuditCurrentUser(userName), cancellationToken);
        }

        public void AuditCurrentUser(string userName)
        {
            // Simulate a long executing process...
            _log.InfoFormat("Action being executed by user={0}", userName);
            // Thread.Sleep(2000);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _log.InfoFormat("Action executed by user={0}", _userSession.Username);
        }

    }
}