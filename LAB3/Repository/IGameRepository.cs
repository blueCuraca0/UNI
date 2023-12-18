interface IGameRepository
{
    void CreateGame(Game game);
    Game ReadGame(int gameID);
    void UpdateGame(int gameID, Game game);
    void DeleteGame(int gameID);
    List<Game> ReadAllGames();
}