using System;
using System.Data;
using System.Security.Principal;

/* 	Примітки:
	1. Методи Win/LoseGame замінені на GameResults, так як з поточною
	   архітектурою їх вміст просто був би однаковим.
*/

class Program
{

    public const int NumOfPlayers = 3;
    public const int NumOfGames = 5;

    public static void Main(string[] args)
    {

        DbContext db = new();

        IAccountService accountService = new AccountService(db);
        IGameService gameService = new GameService(db);

        // Створення гравців
        for (int i = 0; i < NumOfPlayers; i++) accountService.CreateAccount();
        Console.Write("\n"); 

        // Вивести список всіх створених гравців.
        List<GameAccount> allAccounts = accountService.ReadAllAccounts();
        Console.WriteLine("ALL REGISTRED PLAYERS:");
        foreach (GameAccount account in allAccounts) Console.WriteLine($"id {account.Id}  {account.UserName} [{account}]");
        Console.Write("\n");

        // Імітація ігор. Усі аспекти гри (окрім типу самої гри) симулюються випадковим чином
        for (int i = 0; i < NumOfGames; i++) gameService.SimulateGame();
        Console.Write("\n");

        // Виведення статистики
        for (int i = 0; i < NumOfPlayers; i++)
        {
            GameAccount account = accountService.ReadAccount(i);
            Console.WriteLine($"\n\nStats for {account.UserName}:");
            accountService.ReadPlayerGames(account.Id);
        }
        Console.Write("\n");

        Console.WriteLine("\n\nARCHIVE OF ALL PLAYED GAMES");
        gameService.PrintAllGames();

    }
}
