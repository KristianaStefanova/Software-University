using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    using static Common.EntityValidations.Producer;
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }

        public string? PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
            = new HashSet<Album>();  
    } 
}
