namespace LAPTOP.Models
{
    public class Order
    {
        public int Id { get; set; }                 // PK
        public int User_Id { get; set; }
        public string? Status { get; set; }
        public decimal Total { get; set; }
        public string? Payment_Method { get; set; }
    }
}
