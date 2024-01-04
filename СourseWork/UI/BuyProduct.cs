using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class BuyProduct:IUserInterface
{
    private AccountService _accountService;
    private ProductsService _productsService;
    

    public BuyProduct(AccountService accountService, ProductsService productsService)
    {
        _accountService = accountService;
        _productsService = productsService;

    }
    public string Message()
    {
        return "Buy Product";
    }

    public void Action()
    {
        Console.WriteLine("Enter ID of product");
        Console.WriteLine("If tou want to quit type -1");
        int productId = int.Parse(Console.ReadLine());
            var flag = true;
            while (flag)
            {
                if (!_productsService.IsExist(productId))
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Re-enter product ID");
                    Console.WriteLine("If tou want to quit type -1");
                    productId = int.Parse(Console.ReadLine());
                }

                if (_productsService.IsExist(productId))
                {
                    _accountService.AddToBasket(AllMenus.CurrentAccount,productId);
                    _accountService.ConfirmPurchase(AllMenus.CurrentAccount);
                    _productsService.MinusProduct(productId);
                    Serialize();
                    Console.WriteLine("Enter ID of product");
                    Console.WriteLine("If tou want to quit type -1");
                    productId = int.Parse(Console.ReadLine());
                    
                }

                if (productId == -1)
                {
                    flag = false;
                    
                }
                
                
            }
        while (true)
        {
            
            Console.WriteLine("Do you want to continue?\n 1.Yes\n 2.No");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                var menu = new AllMenus();
                menu.Show();
                menu.Action();
                break;
            }

            if (choice == 2)
            {
                break;
            }
        }
        
    }
    private void Serialize()
    {
        JSN.CustomSerialize("Accounts", _accountService.Accounts);
        JSN.CustomSerialize("Products", _productsService.ProductsList);
    }

    
}