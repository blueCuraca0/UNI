internal class AccountService : IAccountService
{

    private IAccountRepository accountRepository;

    public AccountService(DbContext db)
    {
        this.accountRepository = new AccountRepository(db);
    }

    public void CreateAccount()
    {

        Console.Write("\nEnter player's name: ");
        string userName = Console.ReadLine() ?? "[noNameError]";

        Console.Write("Chose account type:\n\tstandard - 1\n\tsoft loses - 2\n\twinning streaks - 3\n");
        string accountType = Console.ReadLine() ?? "1";

        GameAccount account;

        switch (accountType)
        {
            case "1":
                account = new GameAccount(userName);
                accountRepository.CreateAccount(account);
                break;
            case "2":
                account = new SoftLosesGA(userName);
                accountRepository.CreateAccount(account);
                break;
            case "3":
                account = new WinningStreakGA(userName);
                accountRepository.CreateAccount(account);
                break;
            case "4":
                throw new ArgumentException("Невідомий тип акаунту");
        }

    }

    public GameAccount ReadAccount(int accountId)
    {
        return accountRepository.ReadAccount(accountId);
    }

    public void UpdateAccount(int accountId, GameAccount gameAccount)
    {
        accountRepository.UpdateAccount(accountId, gameAccount);
    }

    public void DeleteAccount(int accountId)
    {
        accountRepository.DeleteAccount(accountId);
    }

    public void ReadPlayerGames(int accountId)
    {
        GameAccount account = accountRepository.ReadAccount(accountId);
        account.GetStats(account.UserName);
    }

    public List<GameAccount> ReadAllAccounts()
    {
        return accountRepository.ReadAllAccounts();
    }

}