using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime SentAt { get; set; }

        [Required]
        public MessageStatus Status { get; set; }

        [ForeignKey(nameof(Conversation))]
        public int ConversationId { get; set; }

        public virtual Conversation Conversation { get; set; } = null!;

        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }

        public virtual User Sender { get; set; } = null!;
    }
}
