using СourseWork.Data;
using СourseWork.Data.Service;
using СourseWork.UI.Base;

namespace СourseWork.UI;

public class ShowProducts:IUserInterface
{
    private ProductsService ProductsService { get; }
    public ShowProducts(ProductsService productsService)
    {
        ProductsService = productsService;
    }
    public string Message()
    {
        return "Show all products";
    }

    public void Action()
    {
        List<Products> ProductsList = ProductsService.GetAll();
        foreach (var prod in ProductsList)
        {
            Console.WriteLine($"Product ID: {prod.ID}, Name: {prod.Name}, Price: {prod.Price}, Stock: {prod.Amount}");
        }
        var menu = new AllMenus();
        menu.Show();
        menu.Action();
       
    }
}