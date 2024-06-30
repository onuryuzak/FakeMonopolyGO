using System.Collections.Generic;
using System.IO;
using MyGame.Models;
using UnityEngine;

namespace MyGame.Core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly SerializableDictionary<ItemType, int> _inventory = new();
        private string savePath = Path.Combine(Application.persistentDataPath, "inventory.json");

        public void AddItem(ItemType type, int quantity)
        {
            if (!_inventory.ContainsKey(type))
            {
                _inventory[type] = 0;
            }

            _inventory[type] += quantity;
            Debug.Log(_inventory[type]);
        }

        public int GetItemQuantity(ItemType type)
        {
            return _inventory.ContainsKey(type) ? _inventory[type] : 0;
        }

        public void SaveInventory()
        {
            string json = JsonUtility.ToJson(_inventory);
            File.WriteAllText(savePath, json);
        }


        public void LoadInventory()
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);

                JsonUtility.FromJsonOverwrite(json, _inventory);
            }
        }

        public void ClearInventory()
        {
            _inventory.Clear();
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
                SaveInventory();
            }
        }

        public Dictionary<ItemType, int> GetInventory()
        {
            return new Dictionary<ItemType, int>(_inventory);
        }
    }
}