namespace LAPTOP.Models
{
    public class User
    {
        public int Id { get; set; }                 // PK
        public string? Full_Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
