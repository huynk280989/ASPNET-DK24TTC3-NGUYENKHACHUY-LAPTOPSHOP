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

        public IActionResult Index()
        {
            // laptop ngẫu nhiên
            var hotProducts = _db.Products
                                 .OrderBy(x => Guid.NewGuid())
                                 .Take(5)
                                 .ToList();

            // Laptop Dell (brand_id = 1)
            var dellProducts = _db.Products
                                  .Where(p => p.brand_id == 1)
                                  .ToList();

            // tạo ViewModel
            var vm = new HomeIndexViewModel
            {
                HotProducts = hotProducts,
                DellProducts = dellProducts
            };

            return View(vm);
        }
    }
}
