class Item
{
    public Item() {}
    public Item(string name, int cnt)
    {
        this.name = name;
        this.cnt = cnt;
    }
    
    public string name;
    public int cnt;

    public void addItem(int cnt)
    {
        this.cnt += cnt;
    }

    public void deleteItem(int cnt)
    {
        this.cnt -= cnt;
    }
}
