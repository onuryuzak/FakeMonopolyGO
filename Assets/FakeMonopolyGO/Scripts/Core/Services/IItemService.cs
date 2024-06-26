using System;
using MyGame.Models;

namespace MyGame.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly Random _random = new Random();

        public void GenerateItems(GridSlot[] slots)
        {
            foreach (var slot in slots)
            {
                slot.Item = GenerateRandomItem();
            }
        }

        private Item GenerateRandomItem()
        {
            if (_random.NextDouble() < 0.5)
            {
                return null;
            }

            int enumCount = Enum.GetValues(typeof(ItemType)).Length;
            var itemType = (ItemType)_random.Next(0, enumCount);
            var quantity = _random.Next(1, 6);
            return new Item { Type = itemType, Quantity = quantity };
        }

        public int CollectItem(GridSlot slot)
        {
            if (slot.Item == null)
                return 0;

            int quantity = slot.Item.Quantity;
            slot.Item = null;
            return quantity;
        }
    }
}