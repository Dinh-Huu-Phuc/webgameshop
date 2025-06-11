namespace WebGameShop.Models.Interface
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Product product);
        int RemoveFromCart(Product product);
        List<ShoppingcartItem> GetAllShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        public List<ShoppingcartItem> shopingcartItems { get; set; }
    }
}
