public interface IAccountRepository
{
    void CreateAccount(string login, string password);
    bool LogIn(string login, string password);
    Account ReadAccount(int accountID);
    void UpdateAccount(int accountID, Account account);
    void DeleteAccount(int accountID);
    List<Account> ReadAllAccounts();
    void ReplenishBalance(Account account, int amount);
    void MakePurchase(Account account, Purchase purchase);
}