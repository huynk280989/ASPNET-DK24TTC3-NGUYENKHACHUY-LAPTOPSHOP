using LAPTOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAPTOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly LaptopDbContext _db;

        public HomeController(LaptopDbContext db)
        {
            _db = db;
        }
        public IActionResult Detail(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var related = _db.Products
                             .Where(p => p.brand_id == product.brand_id && p.Id != id)
                             .Take(8)
                             .ToList();

            var vm = new ProductDetailViewModel
            {
                Product = product,
                RelatedProducts = related
            };

            return View(vm);
        }

        public IActionResult Index()
        {
            // Sản phẩm nổi bật (random 5 sản phẩm)
            var hotProducts = _db.Products
                                 .OrderBy(x => Guid.NewGuid())
                                 .Take(5)
                                 .ToList();

            // Laptop Dell (brand_id = 1)
            var dellProducts = _db.Products
                                  .Where(p => p.brand_id == 1)
                                  .ToList();

            // Laptop HP (brand_id = 2)
            var hpProducts = _db.Products
                                  .Where(p => p.brand_id == 2)
                                  .ToList();

            //  Laptop Asus (brand_id = 3)
            var asusProducts = _db.Products
                                  .Where(p => p.brand_id == 3)
                                  .ToList();

            // Laptop Lenovo (brand_id = 4)
            var lenovoProducts = _db.Products
                                    .Where(p => p.brand_id == 4)
                                    .ToList();

            // Tạo ViewModel và truyền vào View
            var vm = new HomeIndexViewModel
            {
                HotProducts = hotProducts,
                DellProducts = dellProducts,
                HPProducts = hpProducts,
                AsusProducts = asusProducts,
                LenovoProducts = lenovoProducts
            };

            return View(vm);
        }
    }
}
