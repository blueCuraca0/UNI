interface IAccountRepository
{
    void CreateAccount(GameAccount account);
    GameAccount ReadAccount(int accountID);
    void UpdateAccount(int accountID, GameAccount account);
    void DeleteAccount(int accountID);
    List<GameAccount> ReadAllAccounts();
}