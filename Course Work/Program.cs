using System;
using System.Collections;
using System.Data;
using System.Numerics;
using System.Security.Principal;

// 	Система для Інтернет Магазину

class Program
{

    public static bool DO_CONTINUE = true;
    public static DbContext db = new();
    public static Account currentUser;
    public static bool isLoggedIn = false;

    public static void Main(string[] args)
    {

        DbContext db = new();

        IAccountService accountService = new AccountService(db);
        IItemService itemService = new ItemService(db);
        IPurchaseService purchaseService = new PurchaseService(db);
         
        itemService.CreateItem("Monitor", 180, 5);
        itemService.CreateItem("Notebook", 3, 120);
        itemService.CreateItem("Charger", 12, 50);
        itemService.CreateItem("Dumbbells", 25, 20);
        itemService.CreateItem("Backpack", 45, 100);
        itemService.CreateItem("Coffee Maker", 100, 40);

        Invoker invoker = new Invoker();

        invoker.SetRegister(new Register());
        invoker.SetLogIn(new LogIn());
        invoker.SetLogOut(new LogOut());
        invoker.SetBuy(new Buy());
        invoker.SetReplenishBalance(new ReplenishBalance());
        invoker.SetShowItems(new ShowItems());
        invoker.SetShowPurchases(new ShowPurchases());
        invoker.SetShowBalance(new ShowBalance());

        invoker.Perform("/help", isLoggedIn, accountService, itemService, purchaseService);

        while (DO_CONTINUE)
        {

            if (currentUser == null)  Console.WriteLine("Please, login or register.");

            Console.WriteLine("Enter a command:");
            string command = Console.ReadLine() ?? "/help";
            invoker.Perform(command, isLoggedIn, accountService, itemService, purchaseService);
            Console.WriteLine("\n==========================================================\n");
        }

    }
}
