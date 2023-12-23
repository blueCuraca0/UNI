public class AccountRepository : IAccountRepository
{
    private DbContext db;

    public AccountRepository(DbContext db)
    {
        this.db = db;
    }

    public void CreateAccount(string login, string password)
    {
        db.Accounts.Add(new Account(login, password));
    }

    public bool LogIn(string login, string password)
    {
        foreach (Account account in db.Accounts) 
        {
            string curLogin = account.Login;
            string curPassword = account.Password;

            if (curLogin == login &&  curPassword == password) 
            {
                Program.currentUser = account;
                Program.isLoggedIn = true;
                return true;
            }
        }

        return false;
    }

    public Account ReadAccount(int accountID)
    {
        return db.Accounts[accountID];
    }

    public void UpdateAccount(int accountID, Account account)
    {
        Account accountToUpdate = db.Accounts[accountID];
        if (accountToUpdate == null) return;
        db.Accounts.Remove(accountToUpdate);
        db.Accounts.Insert(accountID, account);
    }

    public void DeleteAccount(int accountID)
    {
        Account accountToRemove = db.Accounts[accountID];
        if (accountToRemove == null) return;
        db.Accounts.Remove(accountToRemove);
    }
    public List<Account> ReadAllAccounts()
    {
        return db.Accounts;
    }
    public void ReplenishBalance(Account account, int amount)
    {
        account.Balance += amount;
    }
    public void MakePurchase(Account account, Purchase purchase)
    {
        account.MakePurchase(purchase);
    }
}
