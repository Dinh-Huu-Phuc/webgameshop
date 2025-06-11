using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebGameShop.Models;
using WebGameShop.Models.Interface;

namespace WebGameShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View(productRepository.GetAllProducts());
        }
    }
}
