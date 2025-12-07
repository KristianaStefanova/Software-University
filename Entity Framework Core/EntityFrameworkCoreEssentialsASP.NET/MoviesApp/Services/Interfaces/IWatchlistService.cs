using MiniCinemaApp.Data.Models;
using MoviesApp.ViewModels.Movies;

namespace MoviesApp.Services.Interfaces
{
    public interface IWatchlistService
    {
        Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesinWatchlistAsync();  

        Task<bool> AddMovieToWatchlistAsync(int movieId);

        Task RemoveAsync(int movieId);

        Task<bool> MovieExistsInWatchlistAsync(int movieId);
    }
}
