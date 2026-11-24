using MiniCinemaApp.Data.Models;
using MoviesApp.ViewModels.Movies;

namespace MoviesApp.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesForListingAsync();

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(int id);

        Task<AllMoviesIndexViewModel?> GetMoviePrepareDeleteViewModelByIdAsync(int id);

        Task CreateAsync(AddMovieFormModel inputModel);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
