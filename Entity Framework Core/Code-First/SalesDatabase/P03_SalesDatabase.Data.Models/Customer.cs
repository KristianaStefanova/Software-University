using System.ComponentModel.DataAnnotations;
using static P03_SalesDatabase.Common.EntityValidations.Customer;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [MaxLength(CreditCardNumberMaxLength)]
        public string CreditCardNumber { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
           = new HashSet<Sale>();
    }
}
