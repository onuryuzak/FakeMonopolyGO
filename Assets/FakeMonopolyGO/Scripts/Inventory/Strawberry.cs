using UnityEngine;

public class Strawberry : InventoryItem
{
    public Strawberry(int quantity) : base("Strawberry", quantity) { }

    public override void UseItem()
    {
        // Strawberry kullanıldığında yapılacak işlemler
        Debug.Log("Used a Strawberry!");
    }
}