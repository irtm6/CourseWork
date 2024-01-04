using СourseWork.Data.Repository;

namespace СourseWork.Data.Service;

public class ProductsService
{
    private readonly ProductRepository _productRepository;
    public List<Products> ProductsList => _productRepository.ProductsList;

    public ProductsService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Products> GetAll()
    {
        return _productRepository.ProductsList;
    }

    
    public Products GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }
    public bool IsExist(int id)
    {
        return _productRepository.IsExist(id);
    }

    public void MinusProduct(int id)
    {
        _productRepository.MinusProduct(id);
    }
    
}