using MyGame.Models;
using System.Collections.Generic;

namespace MyGame.Core.Services
{
    public interface IInventoryObserver
    {
        void OnInventoryUpdated(Dictionary<ItemType, int> inventory);
    }
}