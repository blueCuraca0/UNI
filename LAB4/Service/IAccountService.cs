interface IAccountService
{
    void CreateAccount();
    GameAccount ReadAccount(int accountId);
    void UpdateAccount(int accountId, GameAccount gameAccount);
    void DeleteAccount(int accountId);
    void ReadPlayerGames(int accountId);
    List<GameAccount> ReadAllAccounts();
    void PrintAllAccounts();
}