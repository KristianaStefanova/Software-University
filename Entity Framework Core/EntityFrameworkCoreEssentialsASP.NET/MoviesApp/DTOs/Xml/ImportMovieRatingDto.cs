using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static MoviesApp.Common.EntityValidation.Movie;

namespace MoviesApp.DTOs.Xml
{
    [XmlType("Rating")]
    public class ImportMovieRatingDto
    {
        [XmlAttribute("source")]
        [MaxLength(MovieRatingSourceMaxLength)]
        public string? RatingSource { get; set; }
    }
}