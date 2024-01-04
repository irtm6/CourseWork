using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class Registration : IUserInterface
{
    private AccountService _accountService { get; set; }

    public Registration(AccountService service)
    {
        _accountService = service;

    }
    public string Message()
    {
        return "Account Registration";
    }

    public void Action()
    {
        Console.WriteLine("Registration");
        Console.WriteLine("Login:");
        string login = Console.ReadLine();
        if (_accountService.IsExist(login.Trim()) || login == "")
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Re-enter login");  
                login = Console.ReadLine();
                if (!_accountService.IsExist(login.Trim()))
                {
                    flag = false;
                }
            }
        }
        Console.WriteLine("Password:");
        string password = Console.ReadLine();
        if (password == "")
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Re-enter password");  
                password = Console.ReadLine();
                if (password != "")
                {
                    flag = false;
                }
            }
        }
        _accountService.AddAccount(login,password);
        Console.WriteLine($"Congratulations! Hello, {login}");
        Console.WriteLine($"Your UID: {_accountService.GetAccountByLog(login).ID}\nYour balance: {_accountService.GetAccountByLog(login).Balance}");
        AllMenus.CurrentAccount = _accountService.GetAccountByLog(login);
        Serialize();
        
        
    }
    private void Serialize()
    {
        JSN.CustomSerialize("Accounts", _accountService.Accounts);
    }
}