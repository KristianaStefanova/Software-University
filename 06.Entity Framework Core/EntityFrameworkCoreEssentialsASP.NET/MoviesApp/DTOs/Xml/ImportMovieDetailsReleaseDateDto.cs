using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static MoviesApp.Common.EntityValidation.Movie;

namespace MoviesApp.DTOs.Xml
{
    [XmlType("Release")]
    public class ImportMovieDetailsReleaseDateDto
    {
        [XmlAttribute("date")]
        [Required]
        [RegularExpression(MovieReleaseDateRegExprPattern)]
        public string Date { get; set; } = null!;
    }
}
