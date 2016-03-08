using AppEstimator.Common.Logging;
using AppEstimator.Common.Security;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Web.Api.AutoMappingConfiguration;
using AppEstimator.Web.Api.Security;
using AppEstimator.Web.Common;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AppEstimator.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            // Configure and Register all depedent services
            builder.RegisterModule(new AppEstimatorModule());
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            // Set the dependency resolver...
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            RegisterHandlers();

            new AutoMapperConfigurator().Configure(
                WebContainerManager.GetAll<IAutoMapperTypeConfigurator>());
        }

        private void RegisterHandlers()
        {
            var logManager = WebContainerManager.Get<ILogManager>();
            
            var userSession = WebContainerManager.Get<IUserSession>();
            var basicSecuritySvc = WebContainerManager.Get<IBasicSecurityService>();
            GlobalConfiguration.Configuration.MessageHandlers.Add(
                new BasicAuthenticationMessageHandler(logManager, basicSecuritySvc));

            GlobalConfiguration.Configuration.MessageHandlers.Add(
                new EstimateDataSecurityMessageHandler(logManager, userSession));
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if(exception != null)
            {
                var log = WebContainerManager.Get<ILogManager>().GetLog(typeof(WebApiApplication));
                log.Error("Unhandled exception.", exception);
            }
        }
    }
}
