using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class Logout:IUserInterface
{
    private AccountService _accountService;
    public ProductsService _productsService;

    public Logout(AccountService accountService, ProductsService productsService)
    {
        _accountService = accountService;
        _productsService = productsService;
    }
    public string Message()
    {
        return "Log out";
    }

    public void Action()
    {
        while (true)
        {
            Console.WriteLine("Do you want to logout?\n 1.Yes\n2.No");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                break;

            }

            if (choice == 2)
            {
                
                Serialize();
                var menu = new AllMenus();
                menu.Run();
            }
        }
    }
    private void Serialize()
    {
        JSN.CustomSerialize("Accounts", _accountService.Accounts);
        JSN.CustomSerialize("Products", _productsService.ProductsList);
    }
}