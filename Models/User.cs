namespace AspVueCrud.Models;
 public class User
{
    public int Id { get; set; }   // Primary key (auto increment in SQLite)
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
    