using Microsoft.EntityFrameworkCore;
using WebGameShop.Data;
using WebGameShop.Models.Interface;

namespace WebGameShop.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private WebGameShopDBContext dbContext;

        public ShoppingCartRepository(WebGameShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ShoppingcartItem>? shopingcartItems { get; set; }
        public string? ShoppingCartId { get; set; }

        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            WebGameShopDBContext context = services.GetService<WebGameShopDBContext>()
                ?? throw new Exception("Error initializing CoffeeshopDbContext");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);

            return new ShoppingCartRepository(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s =>
                s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingcartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Qty = 1,
                };
                dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;
            }

            dbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = dbContext.ShoppingCartItems
                .Where(s => s.ShoppingCartId == ShoppingCartId);

            dbContext.ShoppingCartItems.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }

        public List<ShoppingcartItem> GetAllShoppingCartItems()
        {
            return shopingcartItems ??= dbContext.ShoppingCartItems
                .Where(s => s.ShoppingCartId == ShoppingCartId)
                .Include(p => p.Product)
                .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var totalCost = dbContext.ShoppingCartItems
                .Where(s => s.ShoppingCartId == ShoppingCartId)
                .Select(s => s.Product.Price * s.Qty)
                .Sum();

            return totalCost;
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItems.FirstOrDefault(s =>
                s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            var quantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                    quantity = shoppingCartItem.Qty;
                }
                else
                {
                    dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            dbContext.SaveChanges();
            return quantity;
        }
    }
}
