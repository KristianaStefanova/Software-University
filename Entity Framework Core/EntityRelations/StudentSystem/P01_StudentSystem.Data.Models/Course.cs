using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    using static P01_StudentSystem.Common.EntityValidations.Course;
    public class Course
    {
        [Key]
        public int CourseId { get; set; }


        [Required]
        [MaxLength(NameMaxLength)]
        [Column(TypeName = NameTypeName)]
        public string Name { get; set; } = null!;


        [Column(TypeName = DescriptionTypeName)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; } 

        public DateTime EndDate { get; set; }


        [Column(TypeName = PriceColumnType)]
        public decimal Price { get; set; }

        public virtual ICollection<Resource> Resources { get; set; } 
            = new HashSet<Resource>();

        public virtual ICollection<Homework> Homeworks { get; set; }
            = new HashSet<Homework>();

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        = new HashSet<StudentCourse>();
    }
}
