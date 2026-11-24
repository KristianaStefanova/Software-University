using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CreateRecipeCategoryDropDownModel>> GetCategoriesDropdownDataAsync();
    }
}
