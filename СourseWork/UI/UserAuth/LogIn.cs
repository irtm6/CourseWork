using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class LogIn : IUserInterface
{
    private AccountService _accountService;
    public LogIn(AccountService accountService)
    {
        _accountService = accountService;
        
    }
    public string Message()
    {
        return "Log In";
    }

    public void Action()
    {
        Console.WriteLine("Enter login");
        string login = Console.ReadLine();
        if (!_accountService.IsExist(login.Trim()))
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine("This login doesn`t exist");
                login = "";
                Console.WriteLine("Re-enter login");
                login = Console.ReadLine();
                if (_accountService.IsExist(login.Trim()))
                {
                    flag = false;
                }
            }
        }
        Console.WriteLine("Enter password");
        string password = Console.ReadLine();
        if (_accountService.GetAccountByLog(login).Password != password)
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine("Wrong Password");
                password = "";
                Console.WriteLine("Re-enter password");
                password = Console.ReadLine();
                if (_accountService.GetAccountByLog(login).Password == password)
                {
                    flag = false;
                }
            }
        }
        AllMenus.CurrentAccount = _accountService.GetAccountByLog(login);
        Console.WriteLine($"Hello, {login}\nYour UID: {_accountService.GetAccountByLog(login).ID}\nYour balance: {_accountService.GetAccountByLog(login).Balance}");
    }
}