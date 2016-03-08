using AppEstimator.Common.Logging;
using AppEstimator.Web.Common;
using AppEstimator.Web.Common.ErrorHandling;
using AppEstimator.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;

namespace AppEstimator.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // register a constraints resolver...
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            // register a controller selector...
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            // enable tracing...
            config.Services.Replace(typeof(ITraceWriter), new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));

            // enable error logging...
            config.Services.Add(typeof(IExceptionLogger), new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));

            // register the Global Exception handler...
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }
    }
}
