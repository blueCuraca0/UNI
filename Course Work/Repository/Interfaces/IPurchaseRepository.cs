using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPurchaseRepository
{
    void CreatePurchase(Account account, Item item, int quantity, int totalPrice);
    Purchase ReadPurchaseById(int purchaseID);
    void UpdatePurchaseById(int purchaseID, Purchase purchase);
    void DeletePurchaseById(int purchaseID);
    List<Purchase> ReadAllPurchases();
}
