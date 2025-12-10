using System;
using System.Collections.Generic;

namespace LAPTOP.Models
{
    public class Order
    {
        public int Id { get; set; }

        // Mã đơn theo bảng orders
        public string Order_Code { get; set; }

        // Thông tin khách hàng
        public string Customer_Name { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Address { get; set; }

        // Thanh toán
        public decimal Total { get; set; }
        public string Payment_Method { get; set; }
        public string Status { get; set; }

        // Thời gian
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        // Danh sách sản phẩm trong đơn
        public List<OrderItem> Items { get; set; }
    }
}



