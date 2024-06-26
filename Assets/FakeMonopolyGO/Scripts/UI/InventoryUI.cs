using System;
using System.Collections.Generic;
using MyGame.Core.Services;
using MyGame.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
    public class InventoryUI : MonoBehaviour, IInventoryObserver
    {
        [SerializeField] private TMP_Text _inventoryText;

        private IUIService _uiService;

        public void Initiliaze(IUIService uiService)
        {
            _uiService = uiService;
            Debug.Log("InventoryUI initialized with UIService: " + _uiService);
            Debug.Log("InventoryUI enabled. Registering observer.");
            _uiService?.RegisterInventoryObserver(this);
        }

        private void OnDisable()
        {
            Debug.Log("InventoryUI disabled. Unregistering observer.");
            _uiService?.UnregisterInventoryObserver(this);
        }

        public void OnInventoryUpdated(Dictionary<ItemType, int> inventory)
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