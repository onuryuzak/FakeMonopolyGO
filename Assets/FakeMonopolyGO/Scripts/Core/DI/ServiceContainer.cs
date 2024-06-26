using System;
using System.Collections.Generic;

namespace MyGame.Core.DI
{
    public class ServiceContainer
    {
        private readonly Dictionary<Type, Func<object>> _services = new Dictionary<Type, Func<object>>();

        public void Register<TService>(Func<TService> implementationFactory)
            where TService : class
        {
            _services[typeof(TService)] = () => implementationFactory();
        }

        public TService Resolve<TService>() where TService : class
        {
            if (_services.TryGetValue(typeof(TService), out var serviceFactory))
            {
                return serviceFactory() as TService;
            }
            throw new Exception($"Service of type {typeof(TService)} is not registered.");
        }
    }
}