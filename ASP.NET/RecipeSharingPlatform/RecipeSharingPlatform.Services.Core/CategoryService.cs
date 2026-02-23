using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CreateRecipeCategoryDropDownModel>> GetCategoriesDropdownDataAsync()
        {
            IEnumerable<CreateRecipeCategoryDropDownModel> categoryAsDropdown = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(t => new CreateRecipeCategoryDropDownModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToArrayAsync();

            return categoryAsDropdown;
        }
    }
}
