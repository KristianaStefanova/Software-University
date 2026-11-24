using static ProductShop.Data.EntityValidation.Category;
namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }
            = new HashSet<CategoryProduct>();
    }
}
