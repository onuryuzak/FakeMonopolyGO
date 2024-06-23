using System;

[Serializable]
public abstract class InventoryItem
{
    public string ItemName;
    public int Quantity;

    public InventoryItem(string itemName, int quantity)
    {
        ItemName = itemName;
        Quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
        Quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        Quantity = Math.Max(0, Quantity - amount);
    }

    public abstract void UseItem();
}