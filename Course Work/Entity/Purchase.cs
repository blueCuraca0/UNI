using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Purchase
{
    public static int numPurchases = 0;

    public int ID;
    
    private Account account;

    public Account Account
    {
        get { return account; }
    }

    private Item item;

    public Item Item
    {
        get { return item; }
    }

    private int quantity;

    public int Quantity
    {
        get { return quantity; }
    }

    private int totalPrise;

    public int TotalPrice
    {
        get { return totalPrise; }
    }


    public Purchase(Account account, Item item, int quantity, int totalPrice)
    {
        if (account == null)
        {
            Console.WriteLine("ERROR: Unexisting account");
            throw new ArgumentNullException();
        }

        if (item == null)
        {
            Console.WriteLine("ERROR: Unexisting item");
            throw new ArgumentNullException();
        }

        this.account = account;
        this.item = item;
        this.quantity = quantity;
        this.totalPrise = totalPrice;

        ID = numPurchases;
        numPurchases++;
    }

}
