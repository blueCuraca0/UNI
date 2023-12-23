using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPurchaseService
{
    void CreatePurchase(Account account, Item item, int quantity, int totalPrice);
    Purchase ReadPurchase(int purchaseID);
    void UpdatePurchase(int purchaseID, Purchase purchase);
    void DeletePurchase(int purchaseID);
    List<Purchase> ReadAllPurchases();
    void PrintAllPurchases();
}
