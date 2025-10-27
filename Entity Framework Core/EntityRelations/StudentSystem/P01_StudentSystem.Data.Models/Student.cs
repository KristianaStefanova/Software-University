using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    using static P01_StudentSystem.Common.EntityValidations.Student;
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Column(TypeName = NameTypeName)]
        public string Name { get; set; } = null!;

        [StringLength(PhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
            = new HashSet<Homework>();

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
         = new HashSet<StudentCourse>();
    }
}
