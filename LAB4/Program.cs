using System;
using System.Collections;
using System.Data;
using System.Numerics;
using System.Security.Principal;

/* 	Примітки:
	1. Методи Win/LoseGame замінені на GameResults, так як з поточною
	   архітектурою їх вміст просто був би однаковим.
*/

class Program
{

    public static int NumOfPlayers = 0;

    public static bool DO_CONTINUE = true;

    public static DbContext db = new();

    public IAccountService accountService = new AccountService(db);
    public IGameService gameService = new GameService(db);

    public static void Main(string[] args)
    {

        DbContext db = new();

        IAccountService accountService = new AccountService(db);
        IGameService gameService = new GameService(db);

        Invoker invoker = new Invoker();

        invoker.SetShowUsers(new ShowUsers());
        invoker.SetAddUser(new AddUser());
        invoker.SetStats(new Stats());
        invoker.SetPlayGame(new PlayGame());
        invoker.SetShowGames(new ShowGames());

        invoker.Perform("/help", accountService, gameService);

        while (DO_CONTINUE)
        {
            Console.WriteLine("Enter a command:");
            string command = Console.ReadLine();
            invoker.Perform(command, accountService, gameService);
            Console.WriteLine("==========================================================\n");
        }

    }
}
