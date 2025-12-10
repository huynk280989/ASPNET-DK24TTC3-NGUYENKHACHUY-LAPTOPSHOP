using LAPTOP.Models;
using Microsoft.AspNetCore.Mvc;
using LAPTOP.Extensions;
namespace LAPTOP.Controllers
{
    public class CartController : Controller
    {
        private readonly LaptopDbContext _db;

        public CartController(LaptopDbContext db)
        {
            _db = db;
        }
        public IActionResult Checkout()
{
    var cart = GetCart();
    if (cart.Count == 0)
        return RedirectToAction("Index");

    var vm = new CheckoutViewModel
    {
        CartItems = cart
    };

    return View(vm);
}

        // Lấy giỏ hàng từ session
        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("CART");
            if (cart == null)
            {
                cart = new List<CartItem>();
                HttpContext.Session.SetObject("CART", cart);
            }
            return cart;
        }

        // Lưu lại giỏ
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObject("CART", cart);
        }

        // 1️⃣ Thêm vào giỏ
        public IActionResult Add(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();

            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = id,
                    Name = product.Name,
                    Thumbnail = product.Thumbnail,
                    Price = product.Sale_Price,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            SaveCart(cart);

            return RedirectToAction("Index");
        }

        // 2️⃣ Trang giỏ hàng
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // 3️⃣ Xóa sản phẩm
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null) cart.Remove(item);

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        // 4️⃣ Cập nhật số lượng
        public IActionResult Update(int id, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                item.Quantity = quantity > 0 ? quantity : 1;
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}
