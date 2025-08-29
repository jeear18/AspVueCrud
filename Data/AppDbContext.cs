using AspVueCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AspVueCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Example DbSets (tables)
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }


     protected override void OnModelCreating(ModelBuilder modelBuilder) // Configuring the model for Price property
{
    modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,2)");
}

    }
    
}
