using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PurchaseRepository : IPurchaseRepository
{

    private DbContext db;

    public PurchaseRepository(DbContext db)
    {
        this.db = db;
    }


    public void CreatePurchase(Account account, Item item, int quantity, int totalPrice)
    {
        db.Purchases.Add(new Purchase(account, item, quantity, totalPrice));
    }

    public Purchase ReadPurchaseById(int purchaseID)
    {
        return db.Purchases[purchaseID];
    }

    public void UpdatePurchaseById(int purchaseID, Purchase purchase)
    {
        Purchase purchaseToUpdate = db.Purchases[purchaseID];
        if (purchaseToUpdate == null) return;
        purchase.ID = purchaseID;
        db.Purchases.Remove(purchaseToUpdate);
        db.Purchases.Insert(purchaseID, purchase);
    }


    public void DeletePurchaseById(int purchaseID)
    {
        Purchase purchaseToRemove = db.Purchases[purchaseID];
        if (purchaseToRemove == null) return;
        db.Purchases.Remove(purchaseToRemove);
    }

    public List<Purchase> ReadAllPurchases()
    {
        return db.Purchases;
    }
}
