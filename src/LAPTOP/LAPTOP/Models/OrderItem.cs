namespace LAPTOP.Models
{
    public class OrderItem
    {
        public int Id { get; set; }                 // PK
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
