using Microsoft.AspNetCore.Mvc;
using MiniCinemaApp.Data.Models;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;
using System.Globalization;
using System.Threading.Tasks;

namespace MiniCinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private const string DefaultImageUrl =
            "https://img.freepik.com/free-vector/cinema-film-production-realistic-transparent-composition-with-isolated-image-clapper-with-empty-fields-vector-illustration_1284-66163.jpg?semt=ais_incoming&w=740&q=80";

        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public async Task<IActionResult> Index()
        {
            // Data direction is EXPORT -> from DB to UI -> no need of data validation
            IEnumerable<Movie> allMovies = await this.moviesService
                .GetAllAsync();
            IEnumerable<AllMoviesIndexViewModel> viewModel = allMovies
                .Select(m => new AllMoviesIndexViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    Director = m.Director,
                    ReleaseDate = m.ReleaseDate.ToString(DateTimeFormatInfo.CurrentInfo),
                    Duration = m.Duration,
                    Description = m.Description,
                    ImageUrl = m.ImageUrl,
                });

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddMovieFormModel model = new AddMovieFormModel
            {
                ReleaseDate = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            Movie movie = new Movie
            {
                Title = model.Title,
                Genre = model.Genre,
                ReleaseDate = DateOnly.FromDateTime(model.ReleaseDate),
                Director = model.Director,
                Duration = model.Duration,
                Description = model.Description,
                ImageUrl = string.IsNullOrWhiteSpace(model.ImageUrl)
                    ? DefaultImageUrl
                    : model.ImageUrl
            };

            await this.moviesService.AddAsync(movie);


            return RedirectToAction(nameof(Index));
        }

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


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Movie? movie = await this.moviesService.GetByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            AllMoviesIndexViewModel viewModel = new AllMoviesIndexViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate.ToString(DateTimeFormatInfo.CurrentInfo),
                Duration = movie.Duration,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool movieExists = await this.moviesService.ExistsAsync(id);   
            if (movieExists)
            {
                await this.moviesService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
