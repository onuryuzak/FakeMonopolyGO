using MyGame.Models;
using UnityEngine;

namespace MyGame.Core.Services
{
    public class MapGenerationService : IMapGenerationService
    {
        private readonly IItemService _itemService;

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
        }
    }
}