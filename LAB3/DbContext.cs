public class DbContext
{
    public List<GameAccount> Accounts { get; set; }
    public List<Game> Games { get; set; }

    public DbContext()
    {
        Accounts = new List<GameAccount>();
        Games = new List<Game>();
    }
}