public interface IItemService
{
    void CreateItem(string itemName, int price, int quantity);
    Item ReadItem(int gameId);
    void UpdateItem(int gameId, Item game);
    void DeleteItem(int gameId);
    List<Item> ReadAllItems();
    void PrintAllItems();
}