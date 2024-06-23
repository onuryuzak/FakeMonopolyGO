using System;
using System.Collections.Generic;

public class DIContainer
{
    private Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public void Register<T>()
    {
        _services[typeof(T)] = Activator.CreateInstance<T>();
    }

    public void Register<T>(T service)
    {
        _services[typeof(T)] = service;
    }

    public T Resolve<T>()
    {
        return (T)_services[typeof(T)];
    }
}