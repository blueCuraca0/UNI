using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Invoker
{
    private ICommand showUsers;
    private ICommand addUser;
    private ICommand stats;
    private ICommand playGame;
    private ICommand showGames;


    public void SetShowUsers(ICommand command)
    {
        showUsers = command;
    }

    public void SetAddUser(ICommand command)
    {
        addUser = command;
    }

    public void SetStats(ICommand command)
    {
        stats = command;
    }

    public void SetPlayGame(ICommand command)
    {
        playGame = command;
    }

    public void SetShowGames(ICommand command)
    {
        showGames = command;
    }


    public void Perform(string command, IAccountService accountService, IGameService gameService)
    {
        switch (command)
        {
            case "/showusers":
                showUsers.Execute(accountService);
                break;
            case "/adduser":
                addUser.Execute(accountService);
                break;
            case "/stats":
                stats.Execute(accountService);
                break;
            case "/play":
                playGame.Execute(gameService);
                break;
            case "/showgames":
                showGames.Execute(gameService);
                break;
            case "/exit":
                Program.DO_CONTINUE = false;
                break;
            case "/help":
                Console.WriteLine("\n-------------------- LIST OF COMMANDS --------------------\n" +
                                    "/adduser - " + addUser.Show() +
                                    "\n/showusers - " + showUsers.Show() +
                                    "\n/showgames - " + showGames.Show() +
                                    "\n/stats - " + stats.Show() +
                                    "\n/play - " + playGame.Show() +
                                    "\n/exit - Finishes the work of the program.\n");
                break;
            default:
                Console.WriteLine("ERROR: unknown command");
                break;
        }
    }

}