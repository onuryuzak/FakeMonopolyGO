using UnityEngine;
using MyGame.Core.Services;

namespace MyGame.Game
{
    public class PlayerFactory
    {
        private readonly IItemService _itemService;
        private readonly IInventoryService _inventoryService;
        private readonly IUIService _uiService;

        public PlayerFactory(IItemService itemService, IInventoryService inventoryService, IUIService uiService)
        {
            _itemService = itemService;
            _inventoryService = inventoryService;
            _uiService = uiService;
        }

        public Player CreatePlayer(GameObject playerPrefab)
        {
            var playerObject = Object.Instantiate(playerPrefab);
            playerObject.transform.position = new Vector3(0, 0, -1f);
            var player = playerObject.GetComponent<Player>();
            player.Initialize(_itemService, _inventoryService, _uiService);
            return player;
        }
    }
}