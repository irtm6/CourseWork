using СourseWork.Data;
using СourseWork.Data.Repository;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class AllMenus
{
    private List<IUserInterface> UI { get; set; }
    private AccountRepository accountRepository;
    private AccountService accountService;
    public UserMenu UserMenu;
    public ProductRepository ProductRepository;
    public ProductsService productsService { get; set; }
    public static Account CurrentAccount { get; set; }

    

    public AllMenus()
    {
        DbContext context = new DbContext();
        accountRepository = new AccountRepository(context);
        ProductRepository = new ProductRepository(context);
        productsService = new ProductsService(ProductRepository);
        accountService = new AccountService(accountRepository,productsService);
        UserMenu = new UserMenu(accountService);
        UI = new List<IUserInterface>();
        UI.Add(new AddBalance(accountService));
        UI.Add(new ShowProducts(productsService));
        UI.Add(new BuyProduct(accountService,productsService));
        UI.Add(new ShowHistory(accountService));
        UI.Add(new Logout(accountService, productsService));
    }

    public void Show()
    {
        int i = 1;
        Console.WriteLine("Menu:");
        foreach (var ui in UI)
        {
            Console.WriteLine("{0,2}.{1,3}",i,ui.Message());
            i++;
        }
    }

    public void Action()
    {
        Console.WriteLine("Select option:");
        string option = Console.ReadLine();
        int opt;
        if (!int.TryParse(option, out opt))
        {
            Console.WriteLine("Not a number");
            Action();
        }

        if (opt !=0)
        {
            if (opt > UI.Count || opt < 0)
            {
                Console.WriteLine("There is no such option");
                Action();
            }
            else
            {
                UI[opt-1].Action();
            }
            
        }
        
    }
    
    public void Run()
    {
                
                Console.WriteLine(UserMenu.Message());
                UserMenu.Action();
                Show();
                Action();
               
    }
    
}