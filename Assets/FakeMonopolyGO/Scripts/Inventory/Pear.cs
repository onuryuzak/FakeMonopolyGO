using UnityEngine;

public class Pear : InventoryItem
{
    public Pear(int quantity) : base("Pear", quantity) { }

    public override void UseItem()
    {
        // Pear kullanıldığında yapılacak işlemler
        Debug.Log("Used a Pear!");
    }
}