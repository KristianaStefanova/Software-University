using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Data.Configurations
{
    public class UserRecipeConfiguration : IEntityTypeConfiguration<UserRecipe>
    {
        public void Configure(EntityTypeBuilder<UserRecipe> entity)
        {
            entity
                .HasKey(ur => new { ur.UserId, ur.RecipeId });

            
            entity
                .HasQueryFilter(ud => ud.Recipe.IsDeleted == false);


            entity
                .HasOne(ud => ud.User)
                .WithMany()
                .HasForeignKey(ud => ud.UserId);


            entity
                .HasOne(ud => ud.Recipe)
                .WithMany(d => d.UsersRecipes)
                .HasForeignKey(ud => ud.RecipeId);
        }
    }
}
