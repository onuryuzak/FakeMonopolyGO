namespace MyGame.Models
{
    public class Item
    {
        public ItemType Type { get; set; }
        public int Quantity { get; set; }
    }

    public enum ItemType
    {
        Apple,
        Pear,
        Strawberry
        // Add more item types as needed
    }
}