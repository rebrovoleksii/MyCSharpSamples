using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Core;

namespace People.DiContainer.Viewer
{
    public class ServiceContainer
    {
        private static readonly Dictionary<Type, object> _container = new Dictionary<Type, object>();
        
        public static void RegisterService<T>(object serviceImplementation)
        {
            var serviceType = typeof(T);
            if (_container.ContainsKey(serviceType))
            {
                _container.Remove(serviceType);
            }

            _container.Add(serviceType, serviceImplementation);
        }

        public static T GetService<T>() where T : class
        {
            return GetFromConfig<T>() ?? GetFromContainer<T>();
        }

        private static T GetFromConfig<T>() where T : class
        {
            var repositoryType = ConfigurationManager.AppSettings[typeof(T).ToString()];

            if (string.IsNullOrEmpty(repositoryType))
            {
                return null;
            }
            
            var type = Type.GetType(repositoryType);
            object serviceInstance = Activator.CreateInstance(type);
            // operator as returns either casted type or null
            return serviceInstance as T;
        }

        private static T GetFromContainer<T>() where T : class
        {
            object service;
            _container.TryGetValue(typeof(T), out service);
            return service as T;
        }

    }
}
