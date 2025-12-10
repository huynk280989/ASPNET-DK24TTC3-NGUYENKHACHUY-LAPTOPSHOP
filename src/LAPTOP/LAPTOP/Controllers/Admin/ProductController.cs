using LAPTOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAPTOP.Controllers
{
    public class ProductController : Controller
    {
        private readonly LaptopDbContext _db;

        public ProductController(LaptopDbContext db)
        {
            _db = db;
        }

        /* ================================
         *  LIST
         * ================================ */
        public IActionResult Index()
        {
            var products = _db.Products
                              .OrderByDescending(p => p.Id)
                              .ToList();

            return View("~/Views/Admin/Product/Index.cshtml", products);
        }

        /* ================================
         *  CREATE - GET
         * ================================ */
        public IActionResult Create()
        {
            return View("~/Views/Admin/Product/Create.cshtml");
        }

        /* ================================
         *  CREATE - POST
         * ================================ */
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Admin/Product/Create.cshtml", model);

            _db.Products.Add(model);
            _db.SaveChanges();

            TempData["success"] = "Thêm sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        /* ================================
         *  EDIT - GET
         * ================================ */
        public IActionResult Edit(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            return View("~/Views/Admin/Product/Edit.cshtml", product);
        }

        /* ================================
         *  EDIT - POST
         * ================================ */
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Admin/Product/Edit.cshtml", model);

            var product = _db.Products.FirstOrDefault(x => x.Id == model.Id);
            if (product == null)
                return NotFound();

            // Update fields
            product.Name = model.Name;
            product.Thumbnail = model.Thumbnail;
            product.Price = model.Price;
            product.Sale_Price = model.Sale_Price;

            _db.SaveChanges();

            TempData["success"] = "Cập nhật sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        /* ================================
         *  DELETE
         * ================================ */
        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            _db.Products.Remove(product);
            _db.SaveChanges();

            TempData["success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");
        }
    }
}



