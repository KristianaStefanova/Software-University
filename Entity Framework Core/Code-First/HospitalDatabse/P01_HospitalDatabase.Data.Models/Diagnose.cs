using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static P01_HospitalDatabase.Common.EntityValidations.Diagnose;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }  = null!;

        [Required]
        [MaxLength(CommentsMaxLength)]
        public string Comments { get; set; } = null!;

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; } 

        public virtual Patient Patient { get; set; } = null!;
    }
}
