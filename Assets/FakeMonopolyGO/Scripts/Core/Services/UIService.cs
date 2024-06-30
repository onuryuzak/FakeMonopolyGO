using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Core.Services
{
    public class UIService : IUIService
    {
        private readonly Dictionary<System.Type, IList<object>> _observers = new Dictionary<System.Type, IList<object>>();

        public void RegisterObserver<T>(IObserver<T> observer)
        {
            var type = typeof(T);
            if (!_observers.ContainsKey(type))
            {
                _observers[type] = new List<object>();
            }

            if (!_observers[type].Contains(observer))
            {
                _observers[type].Add(observer);
                Debug.Log($"Observer registered: {observer.GetType().Name}");
            }
            else
            {
                Debug.Log($"Observer already registered: {observer.GetType().Name}");
            }
        }

        public void UnregisterObserver<T>(IObserver<T> observer)
        {
            var type = typeof(T);
            if (_observers.ContainsKey(type))
            {
                if (_observers[type].Contains(observer))
                {
                    _observers[type].Remove(observer);
                    Debug.Log($"Observer unregistered: {observer.GetType().Name}");
                }
            }
        }

        public void NotifyObservers<T>(T data)
        {
            var type = typeof(T);
            if (_observers.ContainsKey(type))
            {
                foreach (var observer in _observers[type])
                {
                    if (observer is IObserver<T> typedObserver)
                    {
                        Debug.Log($"Notifying observer: {observer.GetType().Name}");
                        typedObserver.OnUpdated(data);
                    }
                }
            }
        }   
    }
}