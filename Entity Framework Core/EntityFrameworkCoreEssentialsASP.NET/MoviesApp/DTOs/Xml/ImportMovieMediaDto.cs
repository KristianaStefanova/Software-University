using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static MoviesApp.Common.EntityValidation.Movie;

namespace MoviesApp.DTOs.Xml
{
    [XmlType("Media")]
    public class ImportMovieMediaDto
    {
        [XmlElement("ImageUrl")]
        [MaxLength(MovieImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}