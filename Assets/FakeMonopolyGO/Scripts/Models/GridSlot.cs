using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MyGame.Models
{
    public class GridSlot : MonoBehaviour
    {
        public Item Item { get; set; }
        [SerializeField] private TMP_Text _itemQuantityText;
        [SerializeField] private SpriteRenderer _itemTypeSpriteRenderer;
        [SerializeField] private List<Sprite> _itemTypeTextures;

        private Dictionary<ItemType, Sprite> _itemTypeToSprite;


        public void UpdateVisual()
        {
            _itemTypeToSprite = new Dictionary<ItemType, Sprite>
            {
                { ItemType.Apple, _itemTypeTextures[0] },
                { ItemType.Pear, _itemTypeTextures[1] },
                { ItemType.Strawberry, _itemTypeTextures[2] },
                { ItemType.Empty, null }
            };

            _itemQuantityText.text = Item.Quantity != 0 ? $"{Item.Quantity}" : "";
            _itemTypeSpriteRenderer.sprite =
                _itemTypeToSprite.GetValueOrDefault(Item.Type);
        }
    }
}