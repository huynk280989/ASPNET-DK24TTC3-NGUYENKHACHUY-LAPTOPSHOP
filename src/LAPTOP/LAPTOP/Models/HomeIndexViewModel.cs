namespace LAPTOP.Models
{
    public class HomeIndexViewModel
    {
        public List<Product> HotProducts { get; set; } = new();
        public List<Product> DellProducts { get; set; } = new();
        public List<Product> HPProducts { get; set; } = new();
        public List<Product> AsusProducts { get; set; } = new();
        public List<Product> LenovoProducts { get; set; } = new();
    }
}
