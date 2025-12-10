using LAPTOP.Extensions;
using LAPTOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAPTOP.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly LaptopDbContext _db;

        public CheckoutController(LaptopDbContext db)
        {
            _db = db;
        }

        private string GenerateOrderCode()
        {
            return "#DH" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("CART")
                       ?? new List<CartItem>();

            return View(cart);
        }

        [HttpPost]
        public IActionResult SubmitOrder(string name, string phone, string email, string address)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("CART");

            if (cart == null || cart.Count == 0)
                return RedirectToAction("Index");

            decimal total = cart.Sum(x => x.Price * x.Quantity);

            // Lưu Orders
            var order = new Order
            {
                Order_Code = GenerateOrderCode(),
                Customer_Name = name,
                Customer_Phone = phone,
                Customer_Email = email,
                Customer_Address = address,
                Total = total,
                Payment_Method = "COD",
                Status = "Pending",
                Created_At = DateTime.Now
            };

            _db.Orders.Add(order);
            _db.SaveChanges();

            // Lưu OrderItems
            foreach (var item in cart)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,     // Cột đúng trong DB
                    ProductId = item.ProductId,
                    ProductName = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                _db.OrderItems.Add(orderItem);
            }

            _db.SaveChanges();

            // Xóa giỏ hàng
            HttpContext.Session.SetObject("CART", new List<CartItem>());

            return RedirectToAction("Success", new { id = order.Id });
        }

        public IActionResult Success(int id)
        {
            var order = _db.Orders.FirstOrDefault(x => x.Id == id);
            return View(order);
        }
    }
}



