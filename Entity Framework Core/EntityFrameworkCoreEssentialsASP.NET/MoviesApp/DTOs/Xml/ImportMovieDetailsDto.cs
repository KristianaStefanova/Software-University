using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static MoviesApp.Common.EntityValidation.Movie;

namespace MoviesApp.DTOs.Xml
{
    [XmlType("Details")]
    public class ImportMovieDetailsDto
    {
        [Required]
        [XmlElement("Genre")]
        [MaxLength(MovieGenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required]
        [XmlElement("Director")]
        [MaxLength(MovieDirectorMaxLength)]
        public string Director { get; set; } = null!;

        [XmlElement("Release")]
        public ImportMovieDetailsReleaseDateDto Release { get; set; } = null!;
    }
}