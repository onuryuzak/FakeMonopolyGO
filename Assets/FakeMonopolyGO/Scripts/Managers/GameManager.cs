using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public DIContainer diContainer;

    private void Awake()
    {
        diContainer = new DIContainer();
        diContainer.Register<InventoryManager>();
        inventoryUI.Initialize(diContainer.Resolve<InventoryManager>());
        InventoryManager inv = new InventoryManager();
        inv.Initialize();
    }
}