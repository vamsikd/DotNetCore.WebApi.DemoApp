using DemoApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DemoApp.API.Data
{
    public class DemoAppDbContext : DbContext
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArchivedProduct> ArchivedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seeding categoty table
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Code = "ELECT", Name = "Electronics", Description = "Electronic products", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new Category { Id = 2, Code = "BEAUT", Name = "Beauty", Description = "Beauty cosmetics", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                new Category { Id = 3, Code = "FASHN", Name = "Fashion", Description = "Fashion apperal", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }
            );
        }
    }
}
