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


class ShowUsers : ICommand
{
    public void Execute(object data)
    {
        if (data is AccountService accountService) accountService.PrintAllAccounts();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return("Shows a list of users.");
    }
}

class AddUser: ICommand
{
    public void Execute (object data) 
    {
        if (data is AccountService accountService) accountService.CreateAccount();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Adds a new user.";
    }
}

class Stats : ICommand
{
    public void Execute(object data)
    {
        if (data is AccountService accountService)
        {
            int accountId;
            Console.Write("please, enter player's id: ");
            int.TryParse(Console.ReadLine(), out accountId);
            Console.Write("");
            accountService.ReadPlayerGames(accountId);
        }
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return  "Shows user's statistic (info about thir games).";
    }
}

class PlayGame : ICommand
{
    public void Execute(object data)
    {
        if (data is GameService gameService) gameService.SimulateGame();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Simulated a game.";
    }
}

class ShowGames : ICommand
{
    public void Execute(object data)
    {
        if (data is GameService gameService) gameService.PrintAllGames();
        else Console.WriteLine("ERROR: data was corrupted");
    }

    public string Show()
    {
        return "Shows a list of games (all of them).";
    }
}