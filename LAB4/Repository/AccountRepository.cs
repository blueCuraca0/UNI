internal class AccountRepository : IAccountRepository
{
    private DbContext db;

    public AccountRepository(DbContext db)
    {
        this.db = db;
    }

    public void CreateAccount(GameAccount account)
    {
        db.Accounts.Add(account);
    }

    public GameAccount ReadAccount(int accountID)
    {
        return db.Accounts[accountID];
    }

    public void UpdateAccount(int accountID, GameAccount account)
    {
        var accountToUpdate = db.Accounts[accountID];
        if (accountToUpdate == null) return;
        db.Accounts.Remove(accountToUpdate);
        db.Accounts.Insert(accountID, account);
    }

    public void DeleteAccount(int accountID)
    {
        var accountToRemove = db.Accounts[accountID];
        if (accountToRemove == null) return;
        db.Accounts.Remove(accountToRemove);
    }
    public List<GameAccount> ReadAllAccounts()
    {
        return db.Accounts.ToList();
    }
}
