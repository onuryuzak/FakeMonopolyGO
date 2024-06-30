using UnityEngine;
using TMPro;
using MyGame.Core.Services;
using System.Collections.Generic;
using MyGame.Models;

namespace MyGame.UI
{
    public class InventoryUI : MonoBehaviour, IObserver<Dictionary<ItemType, int>>
    {
        [SerializeField] private TMP_Text _inventoryText;

        private IUIService _uiService;

        public void Initialize(IUIService uiService)
        {
            _uiService = uiService;
            Debug.Log("InventoryUI initialized with UIService: " + _uiService);
            Debug.Log("InventoryUI enabled. Registering observer.");
            _uiService?.RegisterObserver(this);
        }

        private void OnDisable()
        {
            Debug.Log("InventoryUI disabled. Unregistering observer.");
            _uiService?.UnregisterObserver(this);
        }

        public void OnUpdated(Dictionary<ItemType, int> inventory)
        {
            Debug.Log("InventoryUI updated with new inventory data.");
            _inventoryText.text = "";
            foreach (var item in inventory)
            {
                _inventoryText.text += $"{item.Key}: {item.Value}\n";
            }
        }
    }
}