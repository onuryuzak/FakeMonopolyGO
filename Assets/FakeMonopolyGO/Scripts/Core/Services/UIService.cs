using System;
using System.Collections.Generic;
using MyGame.Models;
using UnityEngine;

namespace MyGame.Core.Services
{
    public class UIService : IUIService
    {
        private readonly List<IInventoryObserver> _inventoryObservers = new List<IInventoryObserver>();

        public void RegisterInventoryObserver(IInventoryObserver observer)
        {
            if (!_inventoryObservers.Contains(observer))
            {
                _inventoryObservers.Add(observer);
                Debug.Log("Observer registered: " + observer);
            }
            else
            {
                Debug.Log("Observer already registered: " + observer);
            }
        }

        public void UnregisterInventoryObserver(IInventoryObserver observer)
        {
            if (_inventoryObservers.Contains(observer))
            {
                _inventoryObservers.Remove(observer);
                Debug.Log("Observer unregistered: " + observer);
            }
        }

        public void UpdateInventoryUI(Dictionary<ItemType, int> inventory)
        {
            Debug.Log("Updating Inventory UI. Observer count: " + _inventoryObservers.Count);
            foreach (var observer in _inventoryObservers)
            {
                Debug.Log("Updating observer: " + observer);
                observer.OnInventoryUpdated(inventory);
            }
        }
    }
}