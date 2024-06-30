using System;
using System.Collections.Generic;

namespace MyGame.Core.Services
{
    public interface IUIService
    {
        void RegisterObserver<T>(IObserver<T> observer);
        void UnregisterObserver<T>(IObserver<T> observer);
        void NotifyObservers<T>(T data);
    }
}