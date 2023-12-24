using System;
using System.Collections.Generic;

// 	Поля Клієнта: логін, пароль, баланс, історія покупок (мб ід)
public class Account
{
    public static int numOfAccounts = 0;

    public int ID;

    private string login;

    public string Login
    {
        get { return login; }
        set
        {
            if (!string.IsNullOrEmpty(value)) login = value;
            else Console.WriteLine("[Error: Login cannot be empty]");
        }
    }

    private string password;
    public string Password
    {
        get { return password; }
        set
        {
            if (!string.IsNullOrEmpty(value)) password = value;
            else Console.WriteLine("[Error: Password cannot be empty]");
        }
    }

    private int balance;

    public int Balance
    {
        get { return balance; } 
        set
        {
            // Перевірка, чи значення не менше 1 перед встановленням
            if (value >= 0) balance = value;
            else
            {
                Console.WriteLine("[Error: Balance cannot be negative]");
                balance = 1;
            }
        }
    }

    public int PurchaseCount
    {
        get { return purchaseHistory.Count; }
    }

    private List<Purchase> purchaseHistory;

    public Account(string login, string password)
    {
        Login = login;
        Password = password;
        Balance = 50;   // 50 од. це нараховані бонуси за реєстрацію / на першу покупку
        purchaseHistory = new List<Purchase>();
        ID = numOfAccounts++;
    }

    public void MakePurchase(Purchase purchase)
    {
        purchaseHistory.Add(purchase);
        Balance -= purchase.TotalPrice;
    }

    public List<Purchase> ReadAllPurchases()
    {
        return purchaseHistory;
    }
}