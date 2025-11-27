using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

using static ProductShop.Data.EntityValidation.User;
using static ProductShop.Data.EntityValidation.Product;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {

        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; } = null!;

        public virtual DbSet<Product> Products { get; set; } = null!;
                
        public virtual DbSet<User> Users { get; set; } = null!;
                
        public virtual DbSet<CategoryProduct> CategoriesProducts { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName)
                      .HasMaxLength(FirstNameMaxLength)
                      .IsRequired(false);

                entity.Property(u => u.LastName)
                      .HasMaxLength(LastNameMaxLength)
                      .IsRequired();

                entity.HasMany(u => u.ProductsBought)
                      .WithOne(p => p.Buyer)
                      .HasForeignKey(p => p.BuyerId);

                entity.HasMany(u => u.ProductsSold)
                      .WithOne(p => p.Seller)
                      .HasForeignKey(p => p.SellerId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                      .HasMaxLength(EntityValidation.Product.NameMaxLength)
                      .IsRequired();

                entity.Property(p => p.Price)
                      .HasColumnType(PriceColumnType);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name)
                      .HasMaxLength(EntityValidation.Category.NameMaxLength)
                      .IsRequired();
            });
        }
    }
}
