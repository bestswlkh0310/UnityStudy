using UnityEngine;

public class Item: MonoBehaviour
{
    
    public string itemName;
    public string itemType;
    public int quantity;
    public bool stackable;
    
    public Item() {}
    public Item(string itemName, string itemType, int quantity, bool stackable)
    {
        this.itemName = itemName;
        this.itemType = itemType;
        this.quantity = quantity;
        this.stackable = stackable;
    }
}
