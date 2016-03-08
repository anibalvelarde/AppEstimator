using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace AppEstimator.Web.Common
{
    public static class WebContainerManager
    {
        public static IDependencyResolver GetDependencyResolver()
        {
            var dependencyResolver = GlobalConfiguration.Configuration.DependencyResolver;
            if(dependencyResolver == null)
            {
                throw new InvalidOperationException("The dependency resolver has not been set."); 
            }
            return dependencyResolver;
        }

        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof(T));

            if(service == null)
            {
                throw new NullReferenceException(string.Format("Requested service of type {0}, but none was found.", typeof(T).FullName));
            }
            return (T)service; 
        }

        public static IEnumerable<T> GetAll<T>()
        {
            var services = GetDependencyResolver().GetServices(typeof(T)).ToList();
            if(services.Any())
            {
                return services.Cast<T>();
            }
            throw new NullReferenceException(string.Format("Requested services of type {0}, but none were found.", typeof(T).FullName));
        }
    }
}
