using Microsoft.AspNetCore.Mvc;
using WebGameShop.Models;
using WebGameShop.Models.Interface;
using Microsoft.AspNetCore.Authorization;

namespace WebGameShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        
        private IOrderRepository orderRepository;
        private IShoppingCartRepository shoppingCartRepository;
        public OrdersController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository)
        {
            this.orderRepository = orderRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}
