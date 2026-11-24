using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace P01_StudentSystem.Data.Models
{
    using static P01_StudentSystem.Common.EntityValidations.Resource;
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Column(TypeName = NameTypeName)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = UrlTypeName)]
        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }   

        public virtual Course Course { get; set; } = null!;
    }
}
