using System.Text;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class UserMenu:IUserInterface
{
    private AccountService _service { get; }
    private List<IUserInterface> UI { get; }
    
    public UserMenu(AccountService service)
    {
        _service = service;
        UI = new List<IUserInterface>();
        UI.Add(new LogIn(_service));
        UI.Add(new Registration(_service));
        
        
    }
    public string Message()
    {
        StringBuilder stringBuilder = new StringBuilder();
        int i = 1;
        stringBuilder.AppendLine("Registration or Login menu:");
        foreach (var ui in UI)
        {
            stringBuilder.AppendLine($"{i,2}: {ui.Message()}");
            i++;
        }

        
        return stringBuilder.ToString();

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