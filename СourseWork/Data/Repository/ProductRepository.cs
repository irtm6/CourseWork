namespace СourseWork.Data.Repository;

public class ProductRepository
{
    private readonly DbContext _dbContext;
    public List<Products> ProductsList => _dbContext.Products;
    
    public ProductRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Products> GetAll()
    {
        return _dbContext.Products;
    }
    
    public Products GetProductById(int id)
    {
        return _dbContext.Products.Find(x => x.ID.Equals(id)) ?? throw new Exception("Product not found");
    }
    
    public bool IsExist(int id)
    {
        var list = GetAll();
        bool checker = false;
        foreach (var i in list)
        {
            if (i.ID == id)
            {
                checker = true;

            }
        }
        return checker;
    }

    public void MinusProduct(int id)
    {
        if (GetProductById(id).Amount<=0)
        {
            Console.WriteLine("Not enough products in stock");
        }
        else
        {
            GetProductById(id).Amount--; 
        }
    }
}