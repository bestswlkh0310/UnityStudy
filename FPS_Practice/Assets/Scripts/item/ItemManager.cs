using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private const int itemCnt = 10;
    public static List<IRotatable> items = new();

    void Update()
    {
        RotateItems();
    }

    private void RotateItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].Rotate();
        }
    }
}
