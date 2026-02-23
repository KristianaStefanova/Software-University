using Microsoft.EntityFrameworkCore;

using Horizons.Services.Core.Contracts;
using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Web.ViewModels.Destination;
using static Horizons.GCommon.ValidationConstatnts.Destination;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace Horizons.Services.Core
{
    public class DestinationService : IDestinationService
    {
        private readonly HorizonDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public DestinationService(HorizonDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }


        public async Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationsAsync(string? userId)
        {

            IEnumerable<DestinationIndexViewModel> allDestinations = await this.dbContext
                .Destinations
                .Include(d => d.Terrain)
                .Include(d => d.UsersDestinations)
                .AsNoTracking()
                .Select(d => new DestinationIndexViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    TerrainName = d.Terrain.Name,
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = String.IsNullOrEmpty(userId) == false ?
                        d.PublisherId.ToLower() == userId!.ToLower() : false,
                    IsFavorite = String.IsNullOrEmpty(userId) == false ?
                        d.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId!.ToLower()) : false,

                    
                })
                .ToArrayAsync();

            return allDestinations;
        }

        public async Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? id, string? userId)
        {
            DestinationDetailsViewModel? destinationDetails = null;

            if (id.HasValue)
            {
                Destination? destinationModel = await this.dbContext
                    .Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.Publisher)
                    .Include(d => d.UsersDestinations)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == id.Value);

                if (destinationModel != null)
                {
                    destinationDetails = new DestinationDetailsViewModel()
                    {
                        Id = destinationModel.Id,
                        Name = destinationModel.Name,
                        ImageUrl = destinationModel.ImageUrl,
                        Description = destinationModel.Description,
                        PublishedOn = destinationModel.PublishedOn.ToString(PublishedOnFormat),
                        TerrainName = destinationModel.Terrain.Name,
                        PublisherName = destinationModel.Publisher.UserName,
                        IsPublisher = String.IsNullOrEmpty(userId) == false ?
                           destinationModel.PublisherId.ToLower() == userId.ToLower() : false,
                        IsFavorite = String.IsNullOrEmpty(userId) == false ?
                           destinationModel.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false
                    };
                }
            }

            return destinationDetails;
        }

        public async Task<bool> AddDestinationAsync(string userId, AddDestinationInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Terrain? terrainRef = await this.dbContext
                .Terrains
                .FindAsync(inputModel.TerrainId);

            bool isPublishedOnDateValid = DateTime.TryParseExact(inputModel.PublishedOn, PublishedOnFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null && terrainRef != null && isPublishedOnDateValid)
            {
                Destination newDestination = new Destination()
                {
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    ImageUrl = inputModel.ImageUrl,
                    PublishedOn = publishedOnDate,
                    PublisherId = userId,
                    TerrainId = inputModel.TerrainId,
                };

                await this.dbContext.Destinations.AddAsync(newDestination);
                await this.dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<EditDestinationInputModel?> GetDestinationForEditingAsync(string userId, int? destId)
        {
            EditDestinationInputModel? editModel = null;

            if (destId != null)
            {
                Destination? editDestinationModel = await this.dbContext
                    .Destinations
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (editDestinationModel != null && editDestinationModel.PublisherId.ToLower() == userId.ToLower())
                {
                    editModel = new EditDestinationInputModel()
                    {
                        Id = editDestinationModel.Id,
                        Name = editDestinationModel.Name,
                        Description = editDestinationModel.Description,
                        ImageUrl = editDestinationModel.ImageUrl,
                        TerrainId = editDestinationModel.TerrainId,
                        PublishedOn = editDestinationModel.PublishedOn.ToString(PublishedOnFormat),
                        PublisherId = editDestinationModel.PublisherId,
                    };
                }
            }
            return editModel;
        }

        public async Task<bool> PersistUpdateDestinationAsync(string userId, EditDestinationInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Destination? updateDestination = await this.dbContext
                .Destinations
                .FindAsync(inputModel.Id);

            Terrain? terrainRef = await this.dbContext
                .Terrains
                .FindAsync(inputModel.TerrainId);

            bool isPublishedOnDateValid = DateTime.TryParseExact(inputModel.PublishedOn, PublishedOnFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOnDate);

            if (user != null
                && terrainRef != null
                && updateDestination != null
                && isPublishedOnDateValid
                && updateDestination.PublisherId.ToLower() == userId.ToLower())
            {
                updateDestination.Name = inputModel.Name;
                updateDestination.Description = inputModel.Description;
                updateDestination.PublishedOn = publishedOnDate;
                updateDestination.ImageUrl = inputModel.ImageUrl;
                updateDestination.TerrainId = inputModel.TerrainId;

                await this.dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<DeleteDestinationInputModel?> GetDestinationForDeletingAsync(string userId, int? destId)
        {
            DeleteDestinationInputModel? deleteModel = null;

            if (destId != null)
            {
                Destination? deleteDestinationModel = await this.dbContext
                    .Destinations
                    .Include(d => d.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (deleteDestinationModel != null && deleteDestinationModel.PublisherId.ToLower() == userId.ToLower())
                {
                    deleteModel = new DeleteDestinationInputModel()
                    {
                        Id = deleteDestinationModel.Id,
                        Name = deleteDestinationModel.Name,
                        Publisher = deleteDestinationModel.Publisher.NormalizedUserName,
                        PublisherId = deleteDestinationModel.PublisherId,
                    };
                }
            }
            return deleteModel;
        }

        public async Task<bool> SoftDeleteDestinationAsync(string userId, DeleteDestinationInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Destination? deletedDestination = await this.dbContext
                .Destinations
                .FindAsync(inputModel.Id);

            if (user != null && deletedDestination != null && 
                deletedDestination.PublisherId.ToLower() == userId.ToLower())
            {
                deletedDestination.IsDeleted = true;

                await this.dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<IEnumerable<FavoriteDestinationViewModel>?> GetUserFavoriteDestinationsAsync(string userId)
        {
            IEnumerable<FavoriteDestinationViewModel?> favDestinations = null;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if(user != null)
            {
                favDestinations = await this.dbContext
                    .UsersDestinations
                    .Include(ud => ud.Destination)
                    .ThenInclude(ud => ud.Terrain)
                    .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                    .Select(ud => new FavoriteDestinationViewModel()
                    {
                        Id = ud.DestinationId,
                        Name = ud.Destination.Name,
                        ImageUrl = ud.Destination.ImageUrl,
                        Terrain = ud.Destination.Terrain.Name
                    })
                    .ToArrayAsync();
            }

            return favDestinations;
        }

        public async Task<bool> AddDestinationToUserFavoritesListAsync(string userId, int destId)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Destination? favDestination = await this.dbContext
                .Destinations
                .FindAsync(destId);

            if (user != null && favDestination != null &&
                favDestination.PublisherId.ToLower() != userId.ToLower())
            {
                UserDestination? userFavDestination = await this.dbContext
                    .UsersDestinations
                    .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId && ud.DestinationId == destId);

                if(userFavDestination == null)
                {
                    userFavDestination = new UserDestination()
                    {
                        UserId = userId,
                        DestinationId = destId,
                    };

                    await this.dbContext.UsersDestinations.AddAsync(userFavDestination);
                    await this.dbContext.SaveChangesAsync();

                    operationResult = true;
                }
            }

            return operationResult;
        }

        public async Task<bool> RemoveDestinationFromFavoriteAsync(string userId, int destId)
        {
            bool operationResult = false;

        
            if (string.IsNullOrWhiteSpace(userId))
            {
                return operationResult;
            }

            var userDestinationEntry = await this.dbContext
                .UsersDestinations
                .IgnoreQueryFilters()
                .SingleOrDefaultAsync(ur =>
                    ur.UserId.ToLower() == userId.ToLower() &&
                    ur.DestinationId == destId);

            if (userDestinationEntry != null)
            {
                dbContext.UsersDestinations.Remove(userDestinationEntry);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}

