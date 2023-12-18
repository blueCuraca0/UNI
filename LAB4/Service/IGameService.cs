interface IGameService
{
    void CreateGame(GameAccount player1, GameAccount player2, int ratingPlayer1, int ratingPlayer2, string typeGame);
    Game ReadGame(int gameId);
    void UpdateGame(int gameId, Game game);
    void DeleteGame(int gameId);
    List<Game> ReadAllGames();
    void SimulateGame();
    void PrintAllGames();
}