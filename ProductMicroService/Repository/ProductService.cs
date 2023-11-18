using Microsoft.EntityFrameworkCore;
using ProductMicroService.DBContext;
using ProductMicroService.Model;

namespace ProductMicroService.Repository
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;
        public ProductService(ProductContext context)
        {
            _context = context;

        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public void InsertProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
