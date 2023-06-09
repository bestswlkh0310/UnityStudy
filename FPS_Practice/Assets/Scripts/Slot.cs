using UnityEngine;

internal class Slot: MonoBehaviour
{
    public int idx;
    public Item item = null;

    public Slot(Item item)
    {
        this.item = item;
    }

    public void addItem(int cnt)
    {
        item.addItem(cnt);
    }

    public void deleteItem(int cnt)
    {
        item.deleteItem(cnt);
    }
}
