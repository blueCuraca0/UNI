class ItemRepository : IItemRepository
{

    private DbContext db;

    public ItemRepository(DbContext db)
    {
        this.db = db;
    }

    public void CreateItem(string itemName, int price, int quantity)
    {
        db.Items.Add(new Item(itemName, price, quantity));
    }

    public Item ReadItem(int itemID)
    {
        return db.Items[itemID];
    }

    public void UpdateItem(int itemID, Item item)
    {
        Item itemToUpdate = db.Items[itemID];
        if (itemToUpdate == null) return;
        item.ID = itemID;
        db.Items.Remove(itemToUpdate);
        db.Items.Insert(itemID, item);
    }

    public void DeleteItem(int itemID)
    {
        var itemToRemove = db.Items[itemID];
        if (itemToRemove == null) return;
        db.Items.Remove(itemToRemove);
    }

    public List<Item> ReadAllItems()
    {
        return db.Items.ToList();
    }

}
