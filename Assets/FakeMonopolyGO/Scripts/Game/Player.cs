using UnityEngine;
using MyGame.Core.Services;
using MyGame.Models;

namespace MyGame.Game
{
    public class Player : MonoBehaviour
    {
        private IItemService _itemService;
        private IInventoryService _inventoryService;
        private IUIService _uiService;


        public void Initialize(IItemService itemService, IInventoryService inventoryService, IUIService uiService)
        {
            _itemService = itemService;
            _inventoryService = inventoryService;
            _uiService = uiService;
        }

        public void RollDice(int diceValue)
        {
            var slots = FindObjectOfType<GameInitializer>().gridSlots;
            if (diceValue > 0 && diceValue <= slots.Length)
            {
                var slot = slots[diceValue - 1];
                var collectedQuantity = _itemService.CollectItem(slot);
                _inventoryService.AddItem(slot.Item.Type, collectedQuantity);
                _inventoryService.SaveInventory();
                _uiService.UpdateInventoryUI(_inventoryService.GetInventory());
            }
        }
    }
}