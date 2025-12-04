using Microsoft.EntityFrameworkCore;
using MiniCinemaApp.Data.Models;
using MoviesApp.Data;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MoviesAppDbContext dbContext;

        public MoviesService(MoviesAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Movie movie)
        {
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Movie? movie = await dbContext.Movies.FindAsync(id);

            this.dbContext.Movies.Remove(movie!);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool exists = await this.dbContext
                .Movies
                .AnyAsync(m => m.Id == id);

            return exists;
        }

        // This is example for bad architectural design, just for demo purposes
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            IEnumerable<Movie> allMovies = await this.dbContext
                .Movies
                .AsNoTracking()
                .ToListAsync();

            return allMovies;
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            Movie? movie = await this.dbContext
                .Movies
                .FindAsync(id);

            return movie;
        } 
    }
}
