interface IItemRepository
{
    void CreateItem(string itemName, int price, int quantity);
    Item ReadItem(int itemID);
    void UpdateItem(int itemID, Item item);
    void DeleteItem(int itemID);
    List<Item> ReadAllItems();
}