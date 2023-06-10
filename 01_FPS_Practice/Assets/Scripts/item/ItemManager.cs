using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StringSpriteDict : SerializableDictionary<String, Sprite> {}

public class ItemManager : MonoBehaviour
{
    private const int itemCnt = 10;
    public StringSpriteDict itemImage;
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
