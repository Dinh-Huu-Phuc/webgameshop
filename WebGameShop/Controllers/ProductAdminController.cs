using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGameShop.Data;
using WebGameShop.Models;

namespace WebGameShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductAdminController : Controller
    {
        private readonly WebGameShopDBContext _context;

        public ProductAdminController(WebGameShopDBContext context)
        {
            _context = context;
        }

        // GET: ProductAdmin
        // Hiển thị danh sách tất cả sản phẩm
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: ProductAdmin/Details/5
        // Hiển thị chi tiết một sản phẩm
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductAdmin/Create
        // Hiển thị form để tạo sản phẩm mới
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductAdmin/Create
        // Xử lý việc tạo sản phẩm mới khi form được gửi đi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Detail,ImageUrl,Price,IsTrendingProduct,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductAdmin/Edit/5
        // Hiển thị form để chỉnh sửa sản phẩm hiện có
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductAdmin/Edit/5
        // Xử lý việc cập nhật sản phẩm khi form được gửi đi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Detail,ImageUrl,Price,IsTrendingProduct,Category")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductAdmin/Delete/5
        // Hiển thị trang xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductAdmin/Delete/5
        // Xử lý việc xóa sản phẩm khi xác nhận
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
