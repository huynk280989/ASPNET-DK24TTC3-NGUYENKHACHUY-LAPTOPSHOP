namespace LAPTOP.Models
{
    public class Inventory
    {
        public int Id { get; set; }                 // PK — BẮT BUỘC PHẢI CÓ
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
