namespace LAPTOP.Models
{
    public class Product
    {
        public int Id { get; set; }                 // PK

        public string? Name { get; set; }
        public string? Slug { get; set; }

        public int category_id { get; set; }       
        public int brand_id { get; set; }          

        public decimal Price { get; set; }
        public decimal Sale_Price { get; set; }

        public string? Thumbnail { get; set; }
        public string? Short_Desc { get; set; }
        



    }
}
