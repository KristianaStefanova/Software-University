using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_HospitalDatabase.Common.EntityValidations.Patient;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(AddressMaxLength)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        [Column(TypeName = EmailType)]
        public string Email { get; set; } = null!;

        public bool HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; } 
            = new HashSet<Visitation>();

        public virtual ICollection<Diagnose> Diagnoses { get; set; }
            = new HashSet<Diagnose>();

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
            = new HashSet<PatientMedicament>();
    }
}
