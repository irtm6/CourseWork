using System.Text.Json.Serialization;

namespace СourseWork;

public class Products
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    
    
    
    [JsonConstructor]
    public Products(string name, double price, int id, int amount)
    {
        Name = name;
        Price = price;
        ID = id;
        Amount = amount;
    }
    
   
    
}