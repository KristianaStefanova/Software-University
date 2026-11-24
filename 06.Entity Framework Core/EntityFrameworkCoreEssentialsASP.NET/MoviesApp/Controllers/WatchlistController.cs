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
            IEnumerable<AllMoviesIndexViewModel> moviesInWatchlist = await this.watchlistService
                .GetAllMoviesinWatchlistAsync();

            return View(moviesInWatchlist);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            bool movieExists = await this.moviesService.ExistsAsync(id);
            if (!movieExists)
            {
                return NotFound();
            }

            bool movieAddedToWatclist = await this.watchlistService
                .AddMovieToWatchlistAsync(id);

            bool movieInWatchlistExists = await this.watchlistService
                .MovieExistsInWatchlistAsync(id);
            if (movieAddedToWatclist)
            {
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
    }
}
