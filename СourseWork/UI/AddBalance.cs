using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI
{
    public class AddBalance : IUserInterface
    {
        private readonly AccountService _service;
        

        public AddBalance(AccountService service)
        {
            _service = service;
        }

        public string Message()
        {
            return "Add balance";
        }

        public void Action()
        {
            Console.WriteLine("Input amount:");
            string balanceInput = Console.ReadLine();
            
            if (!double.TryParse(balanceInput, out double amountToAdd) || amountToAdd < 0)
            {
                var flag = true;
                while (flag)
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                    balanceInput = Console.ReadLine();
                    if (double.TryParse(balanceInput, out amountToAdd) || amountToAdd >= 0)
                    {
                        flag = false;
                    }
                }
            }
            _service.AddBalance(AllMenus.CurrentAccount.Login, amountToAdd);
            Console.WriteLine($"Current balance for {AllMenus.CurrentAccount.Login}: {_service.GetBalance(AllMenus.CurrentAccount.Login)}");
            var menu = new AllMenus();
            menu.Show();
            menu.Action();
            Serialize();
        }
       
        private void Serialize()
        {
             JSN.CustomSerialize("Accounts", _service.Accounts);
        }
    }
}