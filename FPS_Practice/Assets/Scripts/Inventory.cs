using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject slotPrefab;
    private const int slotCnt = 5;
    private GameObject[] slots = new GameObject[slotCnt];
    
    void Start()
    {
        CreateSlots();
    }

    void Update()
    {
        
    }

    private void CreateSlots()
    {
        for (int i = 0; i < slotCnt; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab);
            newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
            slots[i] = newSlot;
        }
    }
    
    private void addItem(int idx, Item item, int cnt)
    {
        if (slots[idx] == null)
        {
            slots[idx] = new Slot(item);
        }
        else
        {
            slots[idx].item.addItem(cnt);
        }
    }

    private void deleteItem(int idx)
    {
        if (slots[idx] != null)
        {
            slots[idx] = null;
        }
    }
}
