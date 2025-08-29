namespace AspVueCrud.Models
{
   public class Product
{
    public int Id { get; set; }  // EF Core will make this the PK + Identity automatically
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
}
