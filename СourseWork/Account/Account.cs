using System.Text.Json.Serialization;

namespace СourseWork;

public class Account
{
    public string Login { get; set; }
    public string Password { get; internal set; }
    public int ID { get;  }
    private static int _id = 1;
    public List<Products> Basket { get; }
    public List<Products> History { get; set; }
    public double Balance { get; set; }
    [JsonConstructor]
    public Account(string login, string password)
    {
        Login = login;
        Password = password;
        ID = _id++;
        Balance = 50;
        Basket = new List<Products>();
        History = new List<Products>();
    }
    
}