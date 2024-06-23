using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text inventoryText;
    private InventoryManager inventoryManager;

    public void Initialize(InventoryManager manager)
    {
        if (manager == null)
        {
            Debug.LogError("InventoryManager is null in InventoryUI.");
            return;
        }

        inventoryManager = manager;
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in inventoryManager.GetItems())
        {
            sb.AppendLine($"{item.Key}: {item.Value.Quantity}");
        }
        inventoryText.text = sb.ToString();
    }
}