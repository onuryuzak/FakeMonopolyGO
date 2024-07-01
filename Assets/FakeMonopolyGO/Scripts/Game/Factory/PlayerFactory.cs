using UnityEngine;
using MyGame.Core.Services;

namespace MyGame.Game
{
    public class PlayerFactory
    {
        private readonly IMapGenerationService _mapGenerationService;
        private readonly IInventoryService _inventoryService;
        private readonly IUIService _uiService;


        public PlayerFactory(IMapGenerationService mapGenerationService, IInventoryService inventoryService,
            IUIService uiService)
        {
            _mapGenerationService = mapGenerationService;
            _inventoryService = inventoryService;
            _uiService = uiService;
        }

        public Player CreatePlayer(GameObject playerPrefab)
        {
            var playerObject = Object.Instantiate(playerPrefab);
            playerObject.transform.position = new Vector3(0, 0, -1f);
            var player = playerObject.GetComponent<Player>();
            player.Initialize(_mapGenerationService, _inventoryService,_uiService);
            return player;
        }
    }
}