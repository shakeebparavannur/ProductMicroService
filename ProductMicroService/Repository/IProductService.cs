using ProductMicroService.Model;

namespace ProductMicroService.Repository
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void InsertProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        void Save();
    }
}
