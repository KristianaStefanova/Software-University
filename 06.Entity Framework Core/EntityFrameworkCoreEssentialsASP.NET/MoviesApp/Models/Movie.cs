using System.ComponentModel.DataAnnotations;

using static MoviesApp.Common.EntityValidation.Movie;

namespace MiniCinemaApp.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(MovieTitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(MovieGenreMaxLength)]
        public string Genre { get; set; } = null!;

        public DateOnly ReleaseDate { get; set; }

        [MaxLength(MovieGenreMaxLength)]
        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        [MaxLength(MovieDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(MovieImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}
