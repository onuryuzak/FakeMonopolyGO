using MyGame.Core.DI;
using MyGame.Core.Factories;
using MyGame.Core.Services;
using MyGame.Models;
using MyGame.UI;
using UnityEngine;

namespace MyGame.Game
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Vector3 _cameraOffset;
        [SerializeField] private DiceAnimationSettings _diceAnimationSettings;
        [SerializeField] private InventoryUI _inventoryUI;
        [SerializeField] private DiceInputUI _diceInputUI;
        [SerializeField] private GameObject _gridSlotPrefab;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private int _mapLength = 10;
        [SerializeField] private Vector3 _dice1Offset = new Vector3(-1, 0, 1); // Sol ön
        [SerializeField] private Vector3 _dice2Offset = new Vector3(1, 0, 1); // Sağ ön

        private ServiceContainer _serviceContainer;
        private GridSlot[] _gridSlots;

        private GridSlotFactory _gridSlotFactory;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
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
            _serviceContainer.Register<IDiceAnimationService>(() => new DiceAnimationService(
                _diceAnimationSettings)
            );

            _serviceContainer.Register<IDiceInputService>(() => _diceInputUI);
            _gridSlotFactory = new GridSlotFactory(_gridSlotPrefab);
        }

        private void SetupGame()
        {
            var itemService = _serviceContainer.Resolve<IItemService>();
            var inventoryService = _serviceContainer.Resolve<IInventoryService>();
            var uiService = _serviceContainer.Resolve<IUIService>();
            var mapGenerationService = _serviceContainer.Resolve<IMapGenerationService>();
            var diceInputService = _serviceContainer.Resolve<IDiceInputService>();

            _inventoryUI.Initialize(uiService);
            inventoryService.LoadInventory();
            uiService.NotifyObservers(inventoryService.GetInventory());

            CreateGrids();
            mapGenerationService.GenerateMap(_gridSlots);

            var playerFollowCamera = _camera.GetComponent<PlayerFollowCamera>();
            var playerFactory = new PlayerFactory(mapGenerationService, inventoryService,uiService);
            var diceFactory = new DiceFactory();
            var _dice1Instance = diceFactory.CreateDice(_diceAnimationSettings.Dices[0]);
            var _dice2Instance = diceFactory.CreateDice(_diceAnimationSettings.Dices[1]);
            var _playerInstance = playerFactory.CreatePlayer(_playerPrefab);

            playerFollowCamera.Initialize(_playerInstance.transform, _cameraOffset);

            _dice1Instance.transform.SetParent(_playerInstance.DiceParent);
            _dice1Instance.transform.localPosition = _dice1Offset;
            _dice2Instance.transform.SetParent(_playerInstance.DiceParent);

            _dice2Instance.transform.position = _dice2Offset;

            diceInputService.Initialize(GetServiceContainer(), _dice1Instance, _dice2Instance, _playerInstance);
        }

        private void CreateGrids()
        {
            _gridSlots = new GridSlot[_mapLength];
            for (int i = 0; i < _mapLength; i++)
            {
                _gridSlots[i] = _gridSlotFactory.CreateGridSlot(new Vector3(0, 0, i));
            }
        }

        public ServiceContainer GetServiceContainer()
        {
            return _serviceContainer;
        }
    }
}