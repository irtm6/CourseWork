using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class ShowHistory:IUserInterface
{
    private AccountService _Service{ get; }

    public ShowHistory(AccountService service)
    {
        _Service = service;
    }
    public string Message()
    {
        return "History of purchases";
    }

    public void Action()
    {
        Console.WriteLine(_Service.GetPurchaseHistoryForAccount(AllMenus.CurrentAccount));
        var menu = new AllMenus();
        menu.Show();
        menu.Action();
        
       

    }
    private void Serialize()
    {
        JSN.CustomSerialize("Accounts", _Service.Accounts);
    }
}