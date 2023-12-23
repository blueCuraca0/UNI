using System;
using System.Diagnostics;
using System.Security.AccessControl;

public class ItemService : IItemService
{

    private IItemRepository itemRepository;

    public ItemService(DbContext db) 
    {
        itemRepository = new ItemRepository(db);
    }
        
    public void CreateItem(string itemName, int price, int quantity)
    {
        itemRepository.CreateItem(itemName, price, quantity);
    }

    public Item ReadItem(int gameId)
    {
        return itemRepository.ReadItem(gameId);
    }

    public void UpdateItem(int gameId, Item game)
    {
        itemRepository.UpdateItem(gameId, game);
    }

    public void DeleteItem(int gameId)
    {
        itemRepository.DeleteItem(gameId);
    }

    public List<Item> ReadAllItems()
    {
        return itemRepository.ReadAllItems();
    }

    public void PrintAllItems()
    {
        List<Item> allItems = itemRepository.ReadAllItems();

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("| ID | Item Name            | Price    | Left in stock |");
        Console.WriteLine("--------------------------------------------------------");
                                  
        foreach (Item item in allItems)
        {
            Console.WriteLine($"| {item.ID,-2} | {item.Name,-20} | {item.Price,7}$ | {item.Quantity,-13} |");
        }

        Console.WriteLine("--------------------------------------------------------");
    }

}
