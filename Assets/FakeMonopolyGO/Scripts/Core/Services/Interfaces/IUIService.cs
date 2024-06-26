using MyGame.Models;
using System.Collections.Generic;

namespace MyGame.Core.Services
{
    public interface IUIService
    {
        void RegisterInventoryObserver(IInventoryObserver observer);
        void UnregisterInventoryObserver(IInventoryObserver observer);
        void UpdateInventoryUI(Dictionary<ItemType, int> inventory);
    }
}