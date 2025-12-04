using Microsoft.AspNetCore.Mvc;
using MiniCinemaApp.Controllers;
using MiniCinemaApp.Data.Models;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;
using System.Globalization;

namespace MoviesApp.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly IWatchlistService watchlistService;

        public WatchlistController(IWatchlistService watchlistService,
            IMoviesService moviesService)
        {
            this.watchlistService = watchlistService;
            this.moviesService = moviesService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> movies = await this.watchlistService
                 .GetAllAsync();
            IEnumerable<AllMoviesIndexViewModel> viewModel = movies
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    ReleaseDate = m.ReleaseDate.ToString(CultureInfo.CurrentCulture),
                    Duration = m.Duration,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                });

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            bool movieExists = await this.moviesService.ExistsAsync(id);
            if (!movieExists)
            {
                return NotFound();
            }

            bool movieInWatchlistExists = await this.watchlistService
                .MovieExistsInWatchlistAsync(id);
            if (!movieInWatchlistExists)
            {
                await this.watchlistService.AddAsync(id);

                return RedirectToAction("Index", "Watchlist");
            }

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await this.watchlistService.RemoveAsync(id);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Movie? movie = await this.moviesService.GetByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            MovieDetailsViewModel viewModel = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate.ToDateTime(TimeOnly.MinValue),
                Description = movie.Description,
                ImageUrl = movie.ImageUrl
            };

            return View(viewModel);
        }

    }
}
