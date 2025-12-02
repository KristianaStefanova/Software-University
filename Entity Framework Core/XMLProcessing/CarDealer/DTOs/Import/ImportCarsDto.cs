using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class ImportCarsDto
    {
        [Required]
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [Required]
        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [Required]
        [XmlElement("traveledDistance")]
        public string TravelledDistance { get; set; } = null!;

        [XmlArray("parts")]
        [XmlArrayItem("partId")]
        public ImportPartCarDto[]? PartId { get; set; }

    }
}
