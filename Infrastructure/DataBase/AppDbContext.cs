using InventopryWEB2026.Domin;
using Microsoft.EntityFrameworkCore;

namespace InventopryWEB2026.Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Shelf>().HasKey(s => s.Id);
            modelBuilder.Entity<Warehouse>().HasKey(w => w.Id);
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            // Auto increment (Identity)
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shelf>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Warehouse>().Property(w => w.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().Property(e => e.Id).ValueGeneratedOnAdd();

            // العلاقات
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Shelf)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.ShelfId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.Warehouse)
                .WithMany(w => w.Shelves)
                .HasForeignKey(s => s.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
