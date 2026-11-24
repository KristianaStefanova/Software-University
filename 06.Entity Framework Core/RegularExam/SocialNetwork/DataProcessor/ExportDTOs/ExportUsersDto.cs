using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlRoot("Users")]
    public class ExportUsersDto
    {
        [XmlElement("User")]
        public ExportUserWithPostsDto[] Users { get; set; } = null!;
    }
}

