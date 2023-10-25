using Microsoft.EntityFrameworkCore;
using StoredProcedure.Models;

namespace StoredProcedure.Data
{
    public class APPDbContext : DbContext
    {
        public APPDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
            base.OnModelCreating(modelBuilder);
        }

    }
}
