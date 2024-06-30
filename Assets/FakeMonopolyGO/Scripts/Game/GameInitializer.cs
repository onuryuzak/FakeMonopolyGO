using System;
using UnityEngine;
using MyGame.Core.DI;
using MyGame.Core.Services;
using MyGame.Models;
using MyGame.UI;
using UnityEditor;

namespace MyGame.Game
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private InventoryUI _inventoryUI;
        [SerializeField] private GameObject _gridSlotPrefab;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private int _mapLength = 10;

        private ServiceContainer _serviceContainer;
        private GridSlot[] _gridSlots;

        private void Awake()
        {
            InitializeServices();
            SetupGame();
        }

        private void InitializeServices()
        {
            _serviceContainer = new ServiceContainer();
            _serviceContainer.Register<IItemService>(() => new ItemService());
            _serviceContainer.Register<IInventoryService>(() => new InventoryService());
            _serviceContainer.Register<IUIService>(() => new UIService());
            _serviceContainer.Register<IMapGenerationService>(() => new MapGenerationService(
                _serviceContainer.Resolve<IItemService>()
            ));
        }

        private void SetupGame()
        {
            var itemService = _serviceContainer.Resolve<IItemService>();
            var inventoryService = _serviceContainer.Resolve<IInventoryService>();
            var uiService = _serviceContainer.Resolve<IUIService>();
            var mapGenerationService = _serviceContainer.Resolve<IMapGenerationService>();
            _inventoryUI.Initialize(uiService);
            inventoryService.LoadInventory();
            uiService.NotifyObservers(inventoryService.GetInventory());

            CreateGrids();
            mapGenerationService.GenerateMap(_gridSlots);

            var playerFactory = new PlayerFactory(itemService, inventoryService, uiService);
            // playerFactory.CreatePlayer(playerPrefab);
        }

        private void CreateGrids()
        {
            _gridSlots = new GridSlot[_mapLength];
            for (int i = 0; i < _mapLength; i++)
            {
                GameObject slotObject = Instantiate(_gridSlotPrefab, new Vector3(i, 0, 0), Quaternion.identity);
                _gridSlots[i] = slotObject.GetComponent<GridSlot>();
            }
        }

        public ServiceContainer GetServiceContainer()
        {
            return _serviceContainer;
        }
    }
}