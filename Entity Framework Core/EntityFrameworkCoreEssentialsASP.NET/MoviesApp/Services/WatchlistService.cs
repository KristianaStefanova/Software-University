using Microsoft.EntityFrameworkCore;
using MiniCinemaApp.Data.Models;
using MoviesApp.Data;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly MoviesAppDbContext context;

        public WatchlistService(MoviesAppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(int movieId)
        {
            Watchlist newWatchlist = new Watchlist
            {
                MovieId = movieId
            };

            await this.context.Watchlists.AddAsync(newWatchlist);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            IEnumerable<Movie> allMoviesInWatchlist = await this.context
                .Watchlists
                .AsNoTracking()
                .Include(w => w.Movie)
                .Select(w => w.Movie)
                .ToArrayAsync();

            return allMoviesInWatchlist;
        }

        public async Task<bool> MovieExistsInWatchlistAsync(int movieId)
        {
            bool movieExists = await this.context
                .Watchlists
                .AnyAsync(w => w.MovieId == movieId);

            return movieExists;
        }

        public async Task RemoveAsync(int movieId)
        {
            IEnumerable<Watchlist> watchlistEntryToRemove = await this.context
                .Watchlists
                .AsNoTracking()
                .Where(m => m.MovieId == movieId)
                .ToListAsync();

            this.context.RemoveRange(watchlistEntryToRemove);
            await this.context.SaveChangesAsync();
        }
    }
}
