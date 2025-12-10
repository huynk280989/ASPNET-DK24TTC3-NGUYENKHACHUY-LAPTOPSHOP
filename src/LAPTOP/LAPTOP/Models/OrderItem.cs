using System.ComponentModel.DataAnnotations.Schema;

namespace LAPTOP.Models
{
    [Table("OrderItems")] // Khớp đúng tên bảng trong SQL
    public class OrderItem
    {
        public int Id { get; set; }

        // FK tới bảng Orders
        public int OrderId { get; set; }

        // Thông tin sản phẩm (đã rename)
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Navigation
        public Order Order { get; set; }
    }
}



