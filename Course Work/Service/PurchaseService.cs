using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PurchaseService : IPurchaseService
{

    private IPurchaseRepository purchaseRepository;
    private IItemRepository itemRepository;
    private IAccountRepository accountRepository;

    public PurchaseService(DbContext db)
    {
        purchaseRepository = new PurchaseRepository(db);
        itemRepository = new ItemRepository(db);
        accountRepository = new AccountRepository(db);
    }

    public void CreatePurchase(Account account, Item item, int amount, int totalPrice)
    {
        purchaseRepository.CreatePurchase(account, item, amount, totalPrice);
    }

    public void DeletePurchase(int purchaseID)
    {
        purchaseRepository.DeletePurchaseById(purchaseID);
    }

    public Purchase ReadPurchase(int purchaseID)
    {
        return purchaseRepository.ReadPurchaseById(purchaseID);
    }

    public void UpdatePurchase(int purchaseID, Purchase purchase)
    {
        purchaseRepository.UpdatePurchaseById(purchaseID, purchase);
    }

    public List<Purchase> ReadAllPurchases()
    {
         return purchaseRepository.ReadAllPurchases();
    }

    public void PrintAllPurchases()
    {

        List<Purchase> AllPurchases = purchaseRepository.ReadAllPurchases();

        Console.WriteLine("------------------------------------------------------------------");
        Console.WriteLine("| ID | Customer       | Item         | Quantity | Total Price    |");
        Console.WriteLine("------------------------------------------------------------------");

        foreach (Purchase p in AllPurchases)
        {
            Console.WriteLine($"| {p.ID,-2} | {p.Account.Login,-14} | {p.Item.Name,-12} | {p.Quantity,-8} | {p.TotalPrice,13}$ |");
        }

        Console.WriteLine("------------------------------------------------------------------");
    }
    
}
