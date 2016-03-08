using AppEstimator.Common.Logging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using AppEstimator.Common;
using System.Net.Http.Headers;
using System.Text;

namespace AppEstimator.Web.Api.Security
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        public const char AuthorizationHeaderSeparator = ':';
        private const int UsernameIndex = 0;
        private const int PasswordIndiex = 1;
        private const int ExpectedCredentialCount = 2;

        private readonly ILog _log;
        private readonly IBasicSecurityService _basicSecurityService;

        public BasicAuthenticationMessageHandler(ILogManager logManager, 
            IBasicSecurityService securityService)
        {
            _basicSecurityService = securityService;
            _log = logManager.GetLog(typeof(BasicAuthenticationMessageHandler));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                _log.Debug("Already authenticated; passing on to the next handler...");
                return await base.SendAsync(request, cancellationToken);
            }

            if(!CanHandleAuthentication(request))
            {
                _log.Debug("Not a basic auth request; passing on to next handler");
                return await base.SendAsync(request, cancellationToken);
            }

            bool isAuthenticated;
            try
            {
                isAuthenticated = Authenticate(request);
            }
            catch (Exception e)
            {
                _log.Error("Failure in auth processing", e);
                return CreateUnauthorizedResponse();
            }

            if(isAuthenticated)
            {
                var response = await base.SendAsync(request, cancellationToken);
                return response.StatusCode == HttpStatusCode.Unauthorized ? CreateUnauthorizedResponse() : response;
            }

            return CreateUnauthorizedResponse();
        }

        private HttpResponseMessage CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(Constants.SchemeTypes.Basic));
            return response;
        }

        private bool Authenticate(HttpRequestMessage request)
        {
            _log.Debug("Attempting to authenticate...");
            var authHeader = request.Headers.Authorization;
            if(authHeader == null)
            {
                return false;
            }

            var credentialParts = GetCredentialParts(authHeader);
            if(credentialParts.Length != ExpectedCredentialCount)
            {
                return false;
            }

            return _basicSecurityService.SetPrincipal(credentialParts[UsernameIndex], credentialParts[PasswordIndiex]);
        }

        private string[] GetCredentialParts(AuthenticationHeaderValue authHeader)
        {
            var encodedCredentials = authHeader.Parameter;
            var credentialBytes = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.ASCII.GetString(credentialBytes);
            var credentialParts = credentials.Split(AuthorizationHeaderSeparator);
            return credentialParts;
        }

        private bool CanHandleAuthentication(HttpRequestMessage request)
        {
            return (request.Headers != null
                && request.Headers.Authorization != null
                && request.Headers.Authorization.Scheme.ToLowerInvariant() ==
                    Constants.SchemeTypes.Basic);
        }
    }
}