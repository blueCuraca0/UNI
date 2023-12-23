public class AccountService : IAccountService
{

    private IAccountRepository accountRepository;
    private IPurchaseRepository purchaseRepository;
    private IItemRepository itemRepository;

    public AccountService(DbContext db)
    {
        accountRepository = new AccountRepository(db);
        purchaseRepository = new PurchaseRepository(db);
        itemRepository = new ItemRepository(db);
    }

    public void CreateAccount()
    {
        Console.Write("\nEnter your login: ");
        string login = Console.ReadLine() ?? "[noNameError]";

        Console.Write("\nEnter your password: ");
        string password = Console.ReadLine() ?? "[noPasswordError]";

        accountRepository.CreateAccount(login, password);
        Account.numOfAccounts++;
    }

    public bool LogIn() 
    {
        Console.Write("\nEnter your login: ");
        string login = Console.ReadLine() ?? "[noNameError]";

        Console.Write("\nEnter your password: ");
        string password = Console.ReadLine() ?? "[noPasswordError]";

        if (accountRepository.LogIn(login, password))
        {
            Console.WriteLine("You logged in successfully.");
            return true;
            
        }

        Console.WriteLine("No user was found with given login & password. Please, try again.");
        return false;
    }

    public Account ReadAccount(int accountId)
    {
        return accountRepository.ReadAccount(accountId);
    }

    public void UpdateAccount(int accountId, Account gameAccount)
    {
        accountRepository.UpdateAccount(accountId, gameAccount);
    }

    public void DeleteAccount(int accountId)
    {
        accountRepository.DeleteAccount(accountId);
    }

    public void ReadPlayerGames(int accountId)
    {
        Account account = accountRepository.ReadAccount(accountId);
        account.GetPurchases(account.Login);
    }

    public List<Account> ReadAllAccounts()
    {
        return accountRepository.ReadAllAccounts();
    }

    public void PrintAllAccounts()
    {
        List<Account> allAccounts = accountRepository.ReadAllAccounts();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("ALL REGISTRED CLIENTS:");
        foreach (Account account in allAccounts) 
            Console.WriteLine($"id {account.ID}  {account.Login} [{account}]");
        Console.WriteLine("--------------------------------");
    }

    public void ReplenishBalance()
    {
        Console.Write("Please, enter the amount of money: ");
        string input = Console.ReadLine() ?? "0";
        int amount = 0;
        int.TryParse(input, out amount);
        accountRepository.ReplenishBalance(Program.currentUser, amount);
    }

    public void MakePurchase()
    {
        Account account = Program.currentUser;
        if (account == null)
        {
            Console.WriteLine("[Error: Unable to perform operation on behalf of your user]");
            return;
        }

        Console.Write("Please, enter the ID of the item you want to buy: ");
        string input = Console.ReadLine() ?? "0";
        int itemID = -1;
        int.TryParse(input, out itemID);

        List<Item> allItems = itemRepository.ReadAllItems();
        if (itemID < 0 || itemID > allItems.Count) 
        {
            Console.WriteLine("[Error: Item with the following ID does not exist in the list]");
            return;
        }
        Item item = allItems[itemID];

        Console.Write("Please, enter the number of those items you want to buy: ");
        input = Console.ReadLine() ?? "0";
        int quantity = 0;
        int.TryParse(input, out quantity);

        if (item.Quantity < quantity) 
        {
            Console.WriteLine("[Error: requested more items than are avaliable]");
            return;
        }

        if (item.Price * quantity > account.Balance)
        {
            Console.WriteLine("[Error: not enough funds available for this purchase]");
            return;
        }

        item.Quantity -= quantity;

        purchaseRepository.CreatePurchase(account, item, quantity, item.Price * quantity);
        Purchase purchase = purchaseRepository.ReadPurchaseById(Purchase.numPurchases - 1);
        account.MakePurchase(purchase);
    }

}