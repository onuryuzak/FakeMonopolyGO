using UnityEngine;
using MyGame.Core.DI;
using MyGame.Core.Services;
using MyGame.Models;
using MyGame.UI;

namespace MyGame.Game
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private InventoryUI _inventoryUI;
        private ServiceContainer _serviceContainer;

        public GridSlot[] gridSlots;
        public GameObject playerPrefab;

        private void Awake()
        {
            _serviceContainer = new ServiceContainer();


            _serviceContainer.Register<IItemService>(() => new ItemService());
            _serviceContainer.Register<IInventoryService>(() => new InventoryService());
            _serviceContainer.Register<IUIService>(() => new UIService());


            var _itemService = _serviceContainer.Resolve<IItemService>();
            var _inventoryService = _serviceContainer.Resolve<IInventoryService>();
            var _uiService = _serviceContainer.Resolve<IUIService>();
            _inventoryService.LoadInventory();
            _uiService.UpdateInventoryUI(_inventoryService.GetInventory());
            _inventoryUI.Initiliaze(_uiService);
            // _itemService.GenerateItems(gridSlots);
            // var playerFactory = new PlayerFactory(
            //     _itemService,
            //     _inventoryService,
            //     _uiService
            // );
            // playerFactory.CreatePlayer(playerPrefab);
        }

        public ServiceContainer GetServiceContainer()
        {
            return _serviceContainer;
        }
    }
}