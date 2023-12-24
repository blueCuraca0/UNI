using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Invoker
{

    private ICommand register;
    private ICommand logIn;
    private ICommand logOut;
    private ICommand replenishBalance;
    private ICommand buy;
    private ICommand showItems;
    private ICommand showPurchases;
    private ICommand showBalance;

    public void SetRegister(ICommand command)
    {
        register = command;
    }

    public void SetLogIn(ICommand command)
    {
        logIn = command;
    }
    public void SetLogOut(ICommand command)
    {
        logOut = command;
    }

    public void SetReplenishBalance(ICommand command)
    {
        replenishBalance = command;
    }

    public void SetBuy(ICommand command)
    {
        buy = command;
    }

    public void SetShowItems(ICommand command)
    {
        showItems = command;
    }

    public void SetShowPurchases(ICommand command)
    {
        showPurchases = command;
    }

    public void SetShowBalance(ICommand command)
    {
        showBalance = command;
    }


    public void Perform(string command, bool isLoggedIn, IAccountService accountService, IItemService itemService, IPurchaseService purchaseService)
    {
        if (!isLoggedIn)
        {
            switch (command)
            {
                case "/register":
                    register.Execute(accountService);
                    break;
                case "/login":
                    logIn.Execute(accountService);
                    break;
                case "/help":
                    Console.WriteLine("\n-------------------- LIST OF COMMANDS --------------------\n" +
                                        "/help - shows information about commands that are avaliable for you." +
                                        "\n/login - " + logIn.Show() +
                                        "\n/register - " + register.Show() +
                                        "\n/exit - Finishes the work of the program.\n");
                    break;
                case "/exit":
                    Program.DO_CONTINUE = false;
                    break;
                default:
                    Console.WriteLine("[ERROR: Please, log in or check command's spelling]");
                    break;
            }

            return;
        }

        switch (command)
        {
            case "/replenish":
                replenishBalance.Execute(accountService);
                break;
            case "/buy":
                buy.Execute(accountService);
                break;
            case "/items":
                showItems.Execute(itemService);
                break;
            case "/purchases":
                showPurchases.Execute(purchaseService);
                break;
            case "/balance":
                showBalance.Execute(accountService);
                break;
            case "/logout":
                logOut.Execute(accountService);
                break;
            case "/exit":
                Program.DO_CONTINUE = false;
                break;
            case "/help":
                Console.WriteLine("\n-------------------- LIST OF COMMANDS --------------------\n" +
                                    "/replenish - " + replenishBalance.Show() +
                                    "\n/buy - " + buy.Show() +
                                    "\n/items - " + showItems.Show() +
                                    "\n/purchases - " + showPurchases.Show() +
                                    "\n/balance - " + showBalance.Show() +
                                    "\n/logout - " + logOut.Show() +
                                    "\n/exit - Finishes the work of the program.\n");
                break;
            default:
                Console.WriteLine("[ERROR: unknown command]");
                break;
        }
    }

}