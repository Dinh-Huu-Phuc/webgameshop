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
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            //lưu đơn hàng
            orderRepository.PlaceOrder(order);
            // xóa giỏ hàng sau khi đặt
            shoppingCartRepository.ClearCart();
            //cập nhật số lượng giỏ hàng
            HttpContext.Session.SetInt32("CartCount", 0);
            //chuyển qua trang hoàn thành
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}
