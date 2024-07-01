using MyGame.Models;
using UnityEngine;

namespace MyGame.Core.Services
{
    public class MapGenerationService : IMapGenerationService
    {
        private readonly IItemService _itemService;
        private GridSlot[] _gridSlots;

        public MapGenerationService(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void GenerateMap(GridSlot[] gridSlots)
        {
            foreach (var slot in gridSlots)
            {
                _itemService.GenerateItems(new[] { slot });
                slot.UpdateVisual();
            }

            _gridSlots = gridSlots;
        }

        public GridSlot[] GetGridSlots()
        {
            return _gridSlots;
        }
    }
}