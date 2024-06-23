using UnityEngine;

public class Apple : InventoryItem
{
    public Apple(int quantity) : base("Apple", quantity) { }

    public override void UseItem()
    {
        Debug.Log("Used an Apple!");
    }
}