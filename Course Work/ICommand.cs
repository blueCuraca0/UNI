using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICommand
{
    void Execute(object data);
    string Show();
}

class Register : ICommand
{
    public void Execute(object data)
    {
        if (data is AccountService accountService) accountService.CreateAccount();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Adds a new user.";
    }
}

class LogIn: ICommand
{
    public void Execute (object data) 
    {
        if (data is AccountService accountService) accountService.LogIn();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Logs in an account.";
    }
}

class LogOut : ICommand
{
    public void Execute(object data)
    {
        Program.currentUser = null;
        Program.isLoggedIn = false;
        Console.Clear();
    }

    public string Show()
    {
        return "Logs out of an account.";
    }
}

class ReplenishBalance : ICommand
{
    public void Execute(object data)
    {
        if (data is AccountService accountService) accountService.ReplenishBalance();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Replenished user's balance.";
    }
}

class Buy : ICommand
{
    public void Execute(object data)
    {
        if (data is AccountService accountService) accountService.MakePurchase();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Makes a purchase.";
    }
}

class ShowItems : ICommand
{
    public void Execute(object data)
    {
        if (data is ItemService itemService) itemService.PrintAllItems();
        else Console.WriteLine("ERROR: data was corrupted");

    }

    public string Show()
    {
        return "Shows item's catalog.";
    }
}

class ShowPurchases : ICommand
{
    public void Execute(object data)
    {
        if (data is PurchaseService purchaseService) purchaseService.PrintUsersPurchases();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Shows user's history of purchases.";
    }
}

class ShowBalance : ICommand
{
    public void Execute(object data)
    {
        if (data is AccountService accountService)
        {
            Console.WriteLine("Your current balance is " + Program.currentUser.Balance + "$");
        }
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Shows user's current balance.";
    }
}