public class DbContext
{
    public List<Account> Accounts { get; set; }
    public List<Item> Items { get; set; }
    public List<Purchase> Purchases { get; set; }

    public DbContext()
    {
        Accounts = new List<Account>();
        Items = new List<Item>();
        Purchases = new List<Purchase>();
    }
}