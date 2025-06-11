using WebGameShop.Data;
using WebGameShop.Models.Interface;

namespace WebGameShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private WebGameShopDBContext dbContext;
        public ProductRepository(WebGameShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }

        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);
        }
    }
}
