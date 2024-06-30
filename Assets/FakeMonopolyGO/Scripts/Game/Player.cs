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
    }
}