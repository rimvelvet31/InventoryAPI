using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) 
        {
        }

        // Register models here
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        // Map decimal types to real type in SQLite
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.UnitPrice).HasColumnType("REAL");
            });

            modelBuilder.Entity<Sale>(b =>
            {
                b.Property(s => s.TotalPrice).HasColumnType("REAL");
            });
        }
    }
}
