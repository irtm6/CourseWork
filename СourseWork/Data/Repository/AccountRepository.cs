namespace СourseWork.Data.Repository;

public class AccountRepository
{
    private readonly DbContext _dbContext;
    public List<Account> Accounts => _dbContext.Accounts;
   

    public AccountRepository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public bool IsContain(string login)
    {
        return _dbContext.Accounts.Any(x => x.Login.Equals(login));

    }

    public void AddBalance(double money, string login)
    {
        GetAccountByLog(login).Balance += money;
    }
    public double GetBalance(string login)
    {
        return GetAccountByLog(login).Balance;
    }

    public void Add(Account account)
    {
        if (!IsContain(account.Login))
        {
            _dbContext.Accounts.Add(account);
        }
    }

    public List<Account> GetAll()
    {
        return _dbContext.Accounts;
    }

    public Account GetAccountByLog(string login)
    {
        return _dbContext.Accounts.Find(x => x.Login.Equals(login)); //?? throw new Exception("User not found");
    }

    public Account GetAccountById(int id)
    {
        return _dbContext.Accounts.Find(x => x.ID.Equals(id)) ?? throw new Exception("User not found");
    }
     
    
}