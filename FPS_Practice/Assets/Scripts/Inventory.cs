using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject slotPrefab;
    private const int slotCnt = 5;
    private Item[] items = new Item[slotCnt];
    private GameObject[] slots = new GameObject[slotCnt];
    
    void Start()
    {
        CreateSlots();
    }
    
    private void CreateSlots()
    {
        for (int i = 0; i < slotCnt; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab);
            newSlot.name = "ItemSlot_" + i;
            slots[i] = newSlot;
            newSlot.transform.SetParent(transform);
        }
    }
    
    private void addItem(Item item, int quantity)
    {
        for (int i = 0; i < slotCnt; i++)
        {
            if (items[i] != null && items[i].itemType == item.itemType)
            {
                items[i].quantity++;
            } else if (items[i] == null)
            {
                items[i] = Instantiate(item);
                items[i].quantity = quantity;
            }
        }
    }
}
