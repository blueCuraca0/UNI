public interface IAccountService
{
    void CreateAccount();
    Account ReadAccount(int accountId);
    void UpdateAccount(int accountId, Account gameAccount);
    void DeleteAccount(int accountId);
    void ReadPlayerGames(int accountId);
    List<Account> ReadAllAccounts();
    void PrintAllAccounts();
    bool LogIn();
    void ReplenishBalance();
    void MakePurchase();
}