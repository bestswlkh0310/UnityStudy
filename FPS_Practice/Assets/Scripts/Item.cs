using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract class Item
{
    public Image image;
    public string name;
    public int cnt;

    public void addItem()
    {
        cnt++;
    }

    public void deleteItem()
    {
        cnt--;
    }
}
