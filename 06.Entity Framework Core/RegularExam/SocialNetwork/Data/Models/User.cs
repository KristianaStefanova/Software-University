using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static SocialNetwork.EntityValidation.User;

namespace SocialNetwork.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(PasswordMinLength)]
        public string Password { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
            = new HashSet<Post>();

        public virtual ICollection<Message> Messages { get; set; }
            = new HashSet<Message>();

        public virtual ICollection<UserConversation> UsersConversations { get; set; }
           = new HashSet<UserConversation>();

        public virtual ICollection<Friendship> FriendshipsRequested { get; set; }
            = new HashSet<Friendship>();

        public virtual ICollection<Friendship> FriendshipsReceived { get; set; }
            = new HashSet<Friendship>();
    }
}
