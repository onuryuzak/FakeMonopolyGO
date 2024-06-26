using System.Collections.Generic;
using MyGame.Models;

namespace MyGame.Core.Services
{
    public interface IInventoryService
    {
        void AddItem(ItemType type, int quantity);
        int GetItemQuantity(ItemType type);
        void SaveInventory();
        void LoadInventory();
        Dictionary<ItemType, int> GetInventory(); 
    }
}