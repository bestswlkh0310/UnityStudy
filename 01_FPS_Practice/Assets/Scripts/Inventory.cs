using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemManager;
    static ItemManager _itemManager;
    public GameObject slotPrefab;
    private const int slotCnt = 5;
    
    private static Item[] items = new Item[slotCnt];
    private static GameObject[] slots = new GameObject[slotCnt];
    
    void Start()
    {
        CreateSlots();
        _itemManager = itemManager.GetComponent<ItemManager>();
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
    
    public static bool AddItem(Item item, int quantity)
    {
        for (int i = 0; i < slotCnt; i++)
        {
            if (items[i] != null && items[i].itemType == item.itemType)
            {
                items[i].quantity++;
                // Debug.Log("plus");
                SetSlotText(i);
                return true;
            }
            if (items[i] == null)
            {
                items[i] = item;
                items[i].quantity = quantity;
                // Debug.Log("newItem");
                SetSlotText(i);
                Image slotImage = slots[i].transform.Find("SlotItem").gameObject.GetComponent<Image>();
                slotImage.sprite = _itemManager.itemImage[item.itemName];
                // Debug.Log(_itemManager.itemImage[item.itemName]);
                return true;
            }
        }

        return false;
    }

    private static void SetSlotText(int idx)
    {
        TextMeshProUGUI slotText = slots[idx].transform.Find("SlotText").gameObject.GetComponent<TextMeshProUGUI>();
        slotText.text = items[idx].quantity.ToString();
    }

    public static string toString()
    {
        string result = "";
        foreach (Item item in items)
        {
            if (item != null)
            {
                result += "itemName: " + item.itemName + "\nitemQuantity: " + item.quantity;
            }
        }
        return result;
    }
}
