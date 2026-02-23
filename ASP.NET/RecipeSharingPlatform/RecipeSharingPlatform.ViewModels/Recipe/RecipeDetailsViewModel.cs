using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class RecipeDetailsViewModel : BaseRecipeViewModel
    {
        public string Instructions { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string? Author { get; set; }
    }
}
