using System.ComponentModel.DataAnnotations;
using static P01_HospitalDatabase.Common.EntityValidations.Doctor;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(SpecialtyMaxLength)]
        public string Specialty { get; set; } = null!;

        public virtual ICollection<Visitation> Visitations { get; set; } 
            = new HashSet<Visitation>();
    }
}