using System;
using UnityEngine;
using MyGame.Core.DI;
using MyGame.Core.Services;
using MyGame.Models;
using MyGame.UI;

namespace MyGame.Game
{
    public class TestScript : MonoBehaviour
    {
        private void Start()
        {
            // ServiceContainer serviceContainer = FindObjectOfType<GameInitializer>().GetServiceContainer();
            //
            // IInventoryService inventoryService = serviceContainer.Resolve<IInventoryService>();
            // IUIService uiService = serviceContainer.Resolve<IUIService>();
            // InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
            //
            // // InventoryUI'nun başlatıldığından emin olun
            // inventoryUI.Initiliaze(uiService);
            //
            // // Item ekleyelim
            // // Debug.Log("Adding items to inventory.");
            // // inventoryService.AddItem(ItemType.Apple, 1);
            // // inventoryService.AddItem(ItemType.Strawberry, 1);
            //
            // // Inventory'i kaydedelim
            // Debug.Log("Saving inventory.");
            // // inventoryService.SaveInventory();
            //
            // // Oyuna tekrar girdiğimizde kayıtlı verileri yükleyip UI üzerinde gösterelim
            // // Debug.Log("Loading inventory.");
            // inventoryService.LoadInventory();
            // // Debug.Log("Updating UI with loaded inventory.");
            // uiService.UpdateInventoryUI(inventoryService.GetInventory());
        }
    }
}