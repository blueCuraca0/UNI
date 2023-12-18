class GameRepository : IGameRepository
{

    private DbContext db;

    public GameRepository(DbContext db)
    {
        this.db = db;
    }

    public void CreateGame(Game game)
    {
        db.Games.Add(game);
    }

    public Game ReadGame(int gameID)
    {
        return db.Games[gameID];
    }

    public void UpdateGame(int gameID, Game game)
    {
        var gameToUpdate = db.Games[gameID];
        if (gameToUpdate == null) return;
        game.gameIndex = gameID;
        db.Games.Remove(gameToUpdate);
        db.Games.Insert(gameID ,game);
    }

    public void DeleteGame(int gameID)
    {
        var gameToRemove = db.Games[gameID];
        if (gameToRemove == null) return;
        db.Games.Remove(gameToRemove);
    }

    public List<Game> ReadAllGames()
    {
        return db.Games.ToList();
    }

}
