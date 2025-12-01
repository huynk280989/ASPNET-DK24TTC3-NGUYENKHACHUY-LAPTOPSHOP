namespace LAPTOP.Models
{
    public class CheckoutViewModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        public List<CartItem> CartItems { get; set; }
        public decimal TotalAmount => CartItems.Sum(x => x.Total);
    }
}
