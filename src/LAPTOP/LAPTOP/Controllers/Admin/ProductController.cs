using LAPTOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAPTOP.Controllers.Admin
{
    public class ProductController : Controller
    {
        private readonly LaptopDbContext _db;

        public ProductController(LaptopDbContext db)
        {
            _db = db;
        }

        // LIST
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // DELETE - GET
        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}



