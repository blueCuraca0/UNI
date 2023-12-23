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

    public void GetPurchases(string currentName)
    {

        Console.WriteLine($"Current balance: {Balance}");
        Console.WriteLine($"Total purchases: {PurchaseCount}\n");

        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("| № game | Game Type      | Opponent             | Result        | Players Ratings   |");
        Console.WriteLine("--------------------------------------------------------------------------------------");

        /*for (int i = 0; i < purchaseHistory.Count; i++)
        {

            var game = purchaseHistory[i];
            string opponentName;
            int currentRating;
            int opponentRating;

            bool isEqual = string.Equals(currentName, game.CurrentPlayer.Login);
            if (isEqual)
            {
                opponentName = game.OpponentPlayer.Login;
                currentRating = game.CurrentRating;
                opponentRating = game.OpponentRating;
            }
            else
            {
                opponentName = game.CurrentPlayer.Login;
                currentRating = game.OpponentRating;
                opponentRating = game.CurrentRating;
            }

            Console.WriteLine($"| {game.gameIndex,-6} | {game.Type(),-14} | {opponentName,-20} | {(currentRating < opponentRating ? "LOSE" : "WIN"),-13} | {currentRating,-3} / {opponentRating,-12}|");
        }*/

        Console.WriteLine("--------------------------------------------------------------------------------------");

    }
}