using System;
using MyGame.Models;

namespace MyGame.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly Random _random = new Random();
        private ItemType[] _itemTypes;


        public void GenerateItems(GridSlot[] slots)
        {
            foreach (var slot in slots)
            {
                slot.Item = GenerateRandomItem();
            }
        }

        private Item GenerateRandomItem()
        {
            if (_random.NextDouble() < 0.1)
            {
                return new Item { Type = ItemType.Empty, Quantity = 0 };
            }

            _itemTypes = (ItemType[])Enum.GetValues(typeof(ItemType));
            _itemTypes = Array.FindAll(_itemTypes, itemType => itemType != ItemType.Empty);
            var randomItemType = GetRandomItemType();
            var quantity = _random.Next(1, 6);
            return new Item { Type = randomItemType, Quantity = quantity };
        }

        private ItemType GetRandomItemType()
        {
            int enumCount = _itemTypes.Length;
            int randomIndex = _random.Next(0, enumCount);
            return _itemTypes[randomIndex];
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