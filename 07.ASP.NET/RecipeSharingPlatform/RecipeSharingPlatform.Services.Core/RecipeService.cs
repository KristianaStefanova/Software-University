using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.GCommon;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<bool> CreateRecipeAsync(string userId, CreateRecipeInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager
                .FindByIdAsync(userId);

            Category? categoryRef = await this.dbContext
                .Categories.FindAsync(inputModel.CategoryId);



            if (user != null && categoryRef != null)
            {
                Recipe newDestination = new Recipe()
                {
                    AuthorId = userId,
                    Title = inputModel.Title,
                    ImageUrl = inputModel.ImageUrl,
                    Instructions = inputModel.Instructions,
                    CategoryId = inputModel.CategoryId,
                    CreatedOn = inputModel.CreatedOn,
                };

                await this.dbContext.Recipes.AddAsync(newDestination);
                await this.dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId)
        {
            bool isGuidValid = String.IsNullOrEmpty(userId) && Guid.TryParse(userId, out Guid userGuid);

            IEnumerable<RecipeIndexViewModel> allRecipes = await this.dbContext
                .Recipes
                .AsNoTracking()
                .Select(r => new RecipeIndexViewModel()
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    Category = r.Category.Name,
                    SavedCount = r.UsersRecipes.Count,
                    IsAuthor = String.IsNullOrEmpty(userId) == false ?
                        r.AuthorId.ToLower() == userId!.ToLower() : false,
                    IsSaved = String.IsNullOrEmpty(userId) == false ?
                        r.UsersRecipes.Any(ud => ud.UserId.ToLower() == userId!.ToLower()) : false,
                })
                .ToArrayAsync();

            return allRecipes;
        }

        public async Task<RecipeDetailsViewModel?> GetRecipeDetailsAsync(int? id, string? userId)
        {
            RecipeDetailsViewModel? recipeViewModel = null;

            if (id.HasValue)
            {
                Recipe? recipeModel = await this.dbContext
                    .Recipes
                    .Include(r => r.Category)
                    .Include(r => r.Author)
                    .Include(r => r.UsersRecipes)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == id.Value);

                if (recipeModel != null)
                {
                    recipeViewModel = new RecipeDetailsViewModel()
                    {
                        Id = recipeModel.Id,
                        ImageUrl = recipeModel.ImageUrl,
                        Title = recipeModel.Title,
                        Instructions = recipeModel.Instructions,
                        Category = recipeModel.Category.Name,
                        CreatedOn = recipeModel.CreatedOn,
                        Author = recipeModel.Author.UserName,
                        IsAuthor = !string.IsNullOrEmpty(userId) &&
                                   recipeModel.Author.Id.ToLower() == userId.ToLower(),
                        IsSaved = !string.IsNullOrEmpty(userId) &&
                                  recipeModel.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId.ToLower())
                    };

                }
            }
            return recipeViewModel;


        }

        public async Task<EditRecipeInputModel?> GetRecipeForEditingAsync(string userId, int? recipeId)
        {
            EditRecipeInputModel? editModel = null;

            if (recipeId != null)
            {
                Recipe? editDestinationModel = await this.dbContext
                    .Recipes
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == recipeId);

                if (editDestinationModel != null && editDestinationModel.AuthorId.ToLower() == userId.ToLower())
                {
                    editModel = new EditRecipeInputModel()
                    {
                        Id = editDestinationModel.Id,
                        Title = editDestinationModel.Title,
                        Instructions = editDestinationModel.Instructions,
                        ImageUrl = editDestinationModel.ImageUrl,
                        CategoryId = editDestinationModel.CategoryId,
                        CreatedOn = editDestinationModel.CreatedOn

                    };
                }
            }

            return editModel;
        }

        public async Task<bool> PersistUpdateRecipeAsync(string userId, EditRecipeInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Recipe? updatedRecipe = await this.dbContext
                .Recipes
                .FindAsync(inputModel.Id);

            Console.WriteLine(updatedRecipe == null ? "No se encontró la receta" : "Receta encontrada");


            Category? categoryRef = await this.dbContext
                .Categories
                .FindAsync(inputModel.CategoryId);



            if (user != null &&
                categoryRef != null &&
                updatedRecipe != null &&
                updatedRecipe.AuthorId.ToLower() == userId.ToLower())
            {
                updatedRecipe.Title = inputModel.Title;
                updatedRecipe.Instructions = inputModel.Instructions;
                updatedRecipe.CreatedOn = inputModel.CreatedOn;
                updatedRecipe.ImageUrl = inputModel.ImageUrl;
                updatedRecipe.CategoryId = inputModel.CategoryId;

                await this.dbContext.SaveChangesAsync();

                Console.WriteLine("Cambios guardados correctamente");


                operationResult = true;
            }

            return operationResult;
        }

        public async Task<DeleteRecipeInputModel?> GetRecipeForDeletingAsync(string userId, int? recipeId)
        {
            DeleteRecipeInputModel? deleteModel = null;

            if (recipeId != null)
            {
                Recipe? deleteRecipeModel = await this.dbContext
                    .Recipes
                    .Include(r => r.Author)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == recipeId);

                if (deleteRecipeModel != null && deleteRecipeModel.AuthorId.ToLower() == userId.ToLower())
                {
                    deleteModel = new DeleteRecipeInputModel()
                    {
                        Id = deleteRecipeModel.Id,
                        AuthorId = userId,
                        Title = deleteRecipeModel.Title,
                        Author = deleteRecipeModel.Author?.UserName
                    };
                }
            }
            return deleteModel;
        }

        public async Task<bool> SoftDeleteRecipeAsync(string userId, DeleteRecipeInputModel inputModel)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager
                .FindByIdAsync(userId);

            Recipe? deletedRecipe = await this.dbContext
                .Recipes
                .FindAsync(inputModel.Id);

            if (user != null && deletedRecipe != null &&
                deletedRecipe.AuthorId.ToLower() == userId.ToLower())
            {
                deletedRecipe.IsDeleted = true;

                await this.dbContext.SaveChangesAsync();

                operationResult = true;
            }

            return operationResult;
        }

        public async Task<IEnumerable<FavoriteRecipesViewModel>?> GetFavoriteRecipesAsync(string userId)
        {
            IEnumerable<FavoriteRecipesViewModel>? favRecipes = null;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (user != null)
            {
                favRecipes = await this.dbContext
                    .UserRecipes
                    .Include(ur => ur.Recipe)
                    .ThenInclude(ur => ur.Category)
                    .Where(ur => ur.UserId.ToLower() == userId.ToLower())
                    .Select(ur => new FavoriteRecipesViewModel()
                    {
                        Id = ur.RecipeId,
                        Title = ur.Recipe.Title,
                        ImageUrl = ur.Recipe.ImageUrl,
                        Category = ur.Recipe.Category.Name,
                    })
                     .ToArrayAsync();
            }

            return favRecipes;

        }

        public async Task<bool> AddRecipeToFavoritesAsync(string userId, int recipeId)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Recipe? favRecipe = await this.dbContext
                .Recipes
                .FindAsync(recipeId);

            if (user != null && favRecipe != null && favRecipe.AuthorId.ToLower() != userId.ToLower())
            {
                UserRecipe? userFavRecipe = await this.dbContext
                    .UserRecipes
                    .SingleOrDefaultAsync(ur => ur.UserId.ToLower() == userId.ToLower() &&
                    ur.RecipeId == recipeId);

                if (userFavRecipe == null)
                {
                    userFavRecipe = new UserRecipe()
                    {
                        UserId = userId,
                        RecipeId = recipeId,
                    };

                    await this.dbContext.UserRecipes.AddAsync(userFavRecipe);

                    await this.dbContext.SaveChangesAsync();

                    operationResult = true;
                }
            }

            return operationResult;
        }

        public async Task<bool> RemoveRecipeFromFavoritesListAsync(string userId, int recipeId)
        {

            bool result = false;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            var userRecipeEntry = await this.dbContext
                .UserRecipes
                .IgnoreQueryFilters()
                .SingleOrDefaultAsync(ur =>
                    ur.UserId.ToLower() == userId.ToLower() &&
                    ur.RecipeId == recipeId);

            if (userRecipeEntry != null)
            {
                dbContext.UserRecipes.Remove(userRecipeEntry);
                await dbContext.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}



