using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P03_SalesDatabase.Common.EntityValidations.Product;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Column(TypeName = QuantityType)]
        public decimal Quantity { get; set; }

        [Column(TypeName = PriceType)]
        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
           = new HashSet<Sale>();
    }
}
