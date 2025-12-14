using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static SocialNetwork.EntityValidation.Message;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType("Message")]
    public class ImportMessagesDto
    {
        [XmlAttribute("SentAt")]
        [Required]
        public string SentAt { get; set; } = null!;

        [XmlElement("Content")]
        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [XmlElement("Status")]
        [Required]
        public string Status { get; set; } = null!;

        [XmlElement("ConversationId")]
        [Required]
        public int ConversationId { get; set; }

        [XmlElement("SenderId")]
        [Required]
        public int SenderId { get; set; }
    }
}
