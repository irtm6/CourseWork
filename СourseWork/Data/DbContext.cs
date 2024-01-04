using СourseWork.Data.Service;

namespace СourseWork.Data;

public class DbContext
{
    public List<Account> Accounts { get; }
    public List<Products> Products { get; }
    
    public DbContext()
    {
        Accounts = JSN.CustomDeserialize<List<Account>>("Accounts");
        Products = JSN.CustomDeserialize<List<Products>>("Products");
    }
}