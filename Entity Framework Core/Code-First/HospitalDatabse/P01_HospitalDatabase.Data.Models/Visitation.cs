using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using static P01_HospitalDatabase.Common.EntityValidations.Visitation;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MaxLength(CommentsMaxLength)]
        public string Comments { get; set; } = null!;

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; } 

        public virtual Doctor Doctor { get; set; } = null!;
    }
}
