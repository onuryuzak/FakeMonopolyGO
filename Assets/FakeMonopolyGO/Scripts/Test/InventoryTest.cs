using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public GameManager gameManager;
    public InventoryUI inventoryUI;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryUI.Initialize(gameManager.diContainer.Resolve<InventoryManager>());
        inventoryManager = gameManager.diContainer.Resolve<InventoryManager>();
        // TestAddItems();
        // TestRemoveItems();
        foreach (var item in inventoryManager.GetItems())
        {
            Debug.Log($"{item.Key}: {item.Value.Quantity}");
        }
    }

    private void TestAddItems()
    {
        // DIContainer aracılığıyla InventoryManager'ı alalım

        // InventoryItem'ları oluşturup ekleyelim
        InventoryItem apple = new Apple(5);
        InventoryItem pear = new Pear(3);
        InventoryItem strawberry = new Strawberry(8);

        inventoryManager.AddItem(apple);
        inventoryManager.AddItem(pear);
        inventoryManager.AddItem(strawberry);

        inventoryUI.UpdateInventoryUI();
        foreach (var item in inventoryManager.GetItems())
        {
            Debug.Log($"{item.Key}: {item.Value.Quantity}");
        }
    }

    private void TestRemoveItems()
    {
        // // DIContainer aracılığıyla InventoryManager'ı alalım
        // inventoryManager = diContainer.Resolve<InventoryManager>();
        //
        // // InventoryItem'ları kaldıralım
        // inventoryManager.RemoveItem("Apple", 2);
        // inventoryManager.RemoveItem("Pear", 1);
        //
        // inventoryUI.UpdateInventoryUI();
    }
}