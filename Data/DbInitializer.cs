using AspVueCrud.Models;

namespace AspVueCrud.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            // ✅ Ensure database is created
            context.Database.EnsureCreated();

            // ✅ Seed Products if none exist
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Laptop", Price = 50000 },
                    new Product { Name = "Mouse", Price = 500 },
                    new Product { Name = "Keyboard", Price = 1500 }
                );
            }

            // ✅ Seed Users if none exist
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Username = "admin", Email = "admin@test.com", PasswordHash = "123456" },
                    new User { Username = "john", Email = "john@test.com", PasswordHash = "john123" }
                );
            }

            context.SaveChanges();
        }
    }
}
