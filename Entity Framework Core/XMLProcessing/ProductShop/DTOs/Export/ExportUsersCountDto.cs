using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlRoot("Users")]
    public class ExportUsersCountDto
    {
        [XmlElement("count")]
        public int TotalUserCount { get; set; }

        [XmlArray("users")]
        public ExportUsersWithSoldProductsDto[] Users { get; set; } = null!;
    }
}
