using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Category;

namespace RecipeSharingPlatform.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity
                .HasKey(t => t.Id);

            entity
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

           entity.
               HasData(this.GenerateSeedCategories());
        }

        private List<Category> GenerateSeedCategories()
        {
            List<Category> seedTerrains = new List<Category>()
            {
                  new Category { Id = 1, Name = "Appetizer" },
                  new Category { Id = 2, Name = "Main Dish" },
                  new Category { Id = 3, Name = "Dessert" },
                  new Category { Id = 4, Name = "Soup" },
                  new Category { Id = 5, Name = "Salad" },
                  new Category { Id = 6, Name = "Beverage" }
            };

            return seedTerrains;
        }
    }
}
