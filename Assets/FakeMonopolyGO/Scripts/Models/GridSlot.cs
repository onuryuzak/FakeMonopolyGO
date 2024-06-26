using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace MyGame.Models
{
    public class GridSlot : MonoBehaviour
    {
        public Item Item { get; set; }
        [SerializeField] private TMP_Text _itemText; // TextMeshPro component for display

        public void UpdateVisual()
        {
            _itemText.text = Item != null ? $"{Item.Quantity} {Item.Type}" : "Empty";
        }
    }
}