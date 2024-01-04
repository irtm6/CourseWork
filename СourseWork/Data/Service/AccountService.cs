using System.Text;
using СourseWork.Data.Repository;

namespace СourseWork.Data.Service;

public class AccountService
{
    private ProductsService _productService;
    public List<Account> Accounts => _accountRepository.Accounts;
    
    private readonly AccountRepository _accountRepository;

    public AccountService(AccountRepository accountRepository, ProductsService productService)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _productService = productService;
    }
    public void AddToBasket(Account account, int productID)
    {
        var product = _productService.GetProductById(productID);
        if (product.Amount<=0)
        {
            Console.WriteLine("Not enough products in stock");
        }
        else
        {
            account.Basket.Add(product);
        }
    }

    public void ClearBasket(Account account)
    {
        account.Basket.Clear();
        
    }
    public void ConfirmPurchase(Account account)
    {
        double sum = 0;
        foreach (var product in account.Basket)
        {
            sum += product.Price;
        }

        if (account.Balance < sum)
        {
            Console.WriteLine("Not enough money");
            ClearBasket(account);
        }
        else
        {
            account.Balance -= sum;
            account.History.AddRange(account.Basket);
            ClearBasket(account);
            
        }
    }

    public string GetPurchaseHistoryForAccount(Account account)
    {
        if (account != null && account.History != null && account.History.Any())
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Purchase history for Account ID: {account.ID}, Login: {account.Login}");

            foreach (var product in account.History)
            {
                sb.AppendLine($"Product ID: {product.ID}, Name: {product.Name}, Price: {product.Price}");
            }

            return sb.ToString();
        }
        else
        {
            return "No purchase history available for this account.";
        }
    }

    public bool IsValidBalance(Account account, double balanceInput)
    {
        if (account.Balance < balanceInput)
        {
            return false;

        }

        return true;
    }

    public void AddAccount(string login, string password)
    {
       _accountRepository.Add(Map(new Account(login, password)));
    }

    private Account Map(Account account)
    {
        return new Account(account.Login, account.Password)
        {
            Balance = account.Balance,
            Login = account.Login,
            Password = account.Password
        };
    }

    public void AddBalance(string login, double money)
    {
        _accountRepository.AddBalance(money, login);
    }
    
    public double GetBalance(string login)
    {
       return _accountRepository.GetBalance(login);
    }

    public List<Account> GetAll()
    {
        return _accountRepository.GetAll();
    }

    public Account GetAccountByLog(string login)
    {
            return _accountRepository.GetAccountByLog(login);
    }
    public Account GetAccountById(int id)
    {
        try
        {
            return _accountRepository.GetAccountById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Account not exists");
        }
    }

    public bool IsExist(string login)
    {
        var list = GetAll();
        bool checker = false;
        foreach (var user in list)
        {
            if (user.Login == login)
            {
                checker = true;

            }
        }
        return checker;
    }
}