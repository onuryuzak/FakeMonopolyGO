using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private Dictionary<string, InventoryItem> _items = new Dictionary<string, InventoryItem>();
    private string _saveKey = "InventoryData";

    public void AddItem(InventoryItem newItem)
    {
        if (_items.ContainsKey(newItem.ItemName))
        {
            _items[newItem.ItemName].AddQuantity(newItem.Quantity);
        }
        else
        {
            _items.Add(newItem.ItemName, newItem);
        }

        SaveInventory();
    }

    public void RemoveItem(string itemName, int quantity)
    {
        if (_items.ContainsKey(itemName))
        {
            _items[itemName].RemoveQuantity(quantity);
            if (_items[itemName].Quantity == 0)
            {
                _items.Remove(itemName);
            }

            SaveInventory();
        }
    }

    private void SaveInventory()
    {
        string jsonData = JsonUtility.ToJson(new Serialization<string, InventoryItem>(_items));
        PlayerPrefs.SetString(_saveKey, jsonData);
    }

    private void LoadInventory()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            string jsonData = PlayerPrefs.GetString(_saveKey);
            Debug.Log(jsonData);
            _items = JsonUtility.FromJson<Serialization<string, InventoryItem>>(jsonData).ToDictionary();
            Debug.Log(_items["apple"].Quantity);
        }
    }

    public void Initialize()
    {
        LoadInventory();
    }

    public Dictionary<string, InventoryItem> GetItems()
    {
        return _items;
    }
}