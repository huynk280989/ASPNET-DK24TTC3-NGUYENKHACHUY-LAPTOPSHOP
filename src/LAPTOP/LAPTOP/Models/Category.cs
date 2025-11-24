namespace LAPTOP.Models
{
    public class Category
    {
        public int Id { get; set; }                 // PK
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public int? Parent_Id { get; set; }
    }
}
