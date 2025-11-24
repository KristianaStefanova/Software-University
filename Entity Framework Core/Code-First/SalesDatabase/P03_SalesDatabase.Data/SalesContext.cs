using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using static P03_SalesDatabase.Common.ApplicationConstants;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;

        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Sale> Sales { get; set; } = null!;

        public virtual DbSet<Store> Stores { get; set; } = null!;



        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
