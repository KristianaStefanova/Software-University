using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SocialNetwork.EntityValidation.Post;

namespace SocialNetwork.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; } = null!;
    }
}
