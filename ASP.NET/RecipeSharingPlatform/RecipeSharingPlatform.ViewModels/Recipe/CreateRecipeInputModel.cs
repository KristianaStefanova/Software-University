using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;


        [Required]
        [MinLength(InstructionsMinLength)]
        [MaxLength(InstructionsMaxLength)]
        public string Instructions { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)] 
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        public int CategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public IEnumerable<CreateRecipeCategoryDropDownModel>? Categories { get; set; }



    }
}
