using System;
using System.Security.AccessControl;

internal class GameService : IGameService
{

    Random random = new();

    private IGameRepository gameRepository;
    private IAccountRepository accountRepository;

    public GameService(DbContext db) 
    {
        this.gameRepository = new GameRepository(db);
        this.accountRepository = new AccountRepository(db);
    }

    public void CreateGame(GameAccount player1, GameAccount player2, int ratingPlayer1, int ratingPlayer2, string typeGame)
    {
        Game game = GameFactory.CreateGame(player1, player2, ratingPlayer1, ratingPlayer2, typeGame);
        gameRepository.CreateGame(game);
    }
    public Game ReadGame(int gameId)
    {
        return gameRepository.ReadGame(gameId);
    }

    public void UpdateGame(int gameId, Game game)
    {
        gameRepository.UpdateGame(gameId, game);
    }

    public void DeleteGame(int gameId)
    {
        gameRepository.DeleteGame(gameId);
    }

    public List<Game> ReadAllGames()
    {
        return gameRepository.ReadAllGames();
    }

    public void SimulateGame()
    {
       
        // гравець
        GameAccount CurrentPlayer = accountRepository.ReadAccount(random.Next(0, Program.NumOfPlayers));  
        GameAccount opponent;

        // супротивник (переобирається випадково до тих пір, поки опонент випадає такий же, як і поточний гравець)
        do opponent = accountRepository.ReadAccount(random.Next(0, Program.NumOfPlayers));               
        while (opponent == CurrentPlayer);

        // рейтинги
        int currentRating = random.Next(0, 100);                            
        int opponentRating = random.Next(0, currentRating);

        // тип гри
        Console.Write("\nChose game type:\n\tstandard - 1\n\ttraining - 2\n\tall or nothing - 3\n");
        string gameType = Console.ReadLine() ?? "1";

        // створення гри заданого типу
        Game game = GameFactory.CreateGame(CurrentPlayer, opponent, currentRating, opponentRating, gameType);

        // ↓ результат гри на користь першого випадково обраного гравця (тобто поточного гравця)

        currentRating = game.CalculateRating(currentRating, true);      // обробка за правилами обраної гри
        CurrentPlayer.GameResults(currentRating, true, game);           // обробка за типом акаунту

        opponentRating = game.CalculateRating(opponentRating, false);   // обробка за правилами обраної гри
        opponent.GameResults(opponentRating, false, game);              // обробка за типом акаунту

        gameRepository.CreateGame(game);

        // testing
        Console.WriteLine($"This game: {CurrentPlayer.UserName}: {currentRating}\t {opponent.UserName}: {opponentRating}");
        Console.WriteLine($"Results: {CurrentPlayer.UserName}: {CurrentPlayer.Rating}\t {opponent.UserName}: {opponent.Rating}");

    }

    public void PrintAllGames()
    {
        List<Game> allGames = gameRepository.ReadAllGames();

        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("| №  | Game Type       | Player 1             | Score | Player 2             | Score |");
        Console.WriteLine("--------------------------------------------------------------------------------------");
                                  
        foreach (Game game in allGames)
        {
            Console.WriteLine(  $"| {game.gameIndex,-2} | {game.Type(),-15} " +
                                $"| {game.CurrentPlayer.UserName,-20} | {game.CurrentRating,-5} " +
                                $"| {game.OpponentPlayer.UserName,-20} | {game.OpponentRating,-5} |");


            /*Console.WriteLine(  $"Game: {game.CurrentPlayer.UserName}: {game.CurrentRating}\t " +
                                $"{game.OpponentPlayer.UserName}: {game.OpponentRating}");;*/
        }

        Console.WriteLine("--------------------------------------------------------------------------------------");
    }
}
