using System.ComponentModel.DataAnnotations;
using static MoviesApp.Common.EntityValidation.Movie;

namespace MoviesApp.DTOs.Json
{
    public class ImportJsonMovieDto
    {
        [Required]
        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MovieGenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Required]
        [MaxLength(MovieDirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Range(MovieDurationMinValue, MovieDurationMaxValue)]
        public int Duration { get; set; }

        [Required]
        [MaxLength(MovieDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(MovieImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }

}
