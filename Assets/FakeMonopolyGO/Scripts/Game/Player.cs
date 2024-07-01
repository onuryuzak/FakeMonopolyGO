using UnityEngine;
using MyGame.Core.Services;
using MyGame.Models;

namespace MyGame.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform _diceParent;
        [SerializeField] private float _moveSpeed = 2f;


        public Transform DiceParent => _diceParent;
        private int currentPlayerIndex = 0;
        private IMapGenerationService _mapGenerationService;
        private IInventoryService _inventoryService;
        private IUIService _uiService;
        private Vector3 _targetPosition;
        private bool _isMoving;


        public void Initialize(IMapGenerationService mapGenerationService, IInventoryService inventoryService,
            IUIService uiService)
        {
            _mapGenerationService = mapGenerationService;
            _inventoryService = inventoryService;
            _uiService = uiService;
        }

        private void Update()
        {
            if (!_isMoving) return;
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            {
                transform.position = _targetPosition;
            }
        }

        public void Move(int steps)
        {
            var gridSlots = _mapGenerationService.GetGridSlots();
            int totalGrids = gridSlots.Length;
            currentPlayerIndex = (currentPlayerIndex + steps) % totalGrids;
            transform.position = gridSlots[currentPlayerIndex].transform.position;
            _inventoryService.AddItem(gridSlots[currentPlayerIndex].Item.Type,
                gridSlots[currentPlayerIndex].Item.Quantity);
            _uiService.NotifyObservers(_inventoryService.GetInventory());

            _isMoving = true;
        }
    }
}