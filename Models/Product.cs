namespace AspVueCrud.Models
{
    public class Product
    {
        public int Id { get; set; }   // Primary key (auto increment in SQLite)
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
