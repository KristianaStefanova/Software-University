using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId);

        Task<RecipeDetailsViewModel?> GetRecipeDetailsAsync(int? id, string? userId);

        Task<bool> CreateRecipeAsync(string userId, CreateRecipeInputModel inputModel);

        Task<EditRecipeInputModel?> GetRecipeForEditingAsync(string userId, int? recipeId);

        Task<bool> PersistUpdateRecipeAsync(string userId, EditRecipeInputModel inputModel);

        Task<DeleteRecipeInputModel?> GetRecipeForDeletingAsync(string userId, int? recipeId);

        Task<bool> SoftDeleteRecipeAsync(string userId, DeleteRecipeInputModel inputModel);

        Task<IEnumerable<FavoriteRecipesViewModel>?> GetFavoriteRecipesAsync(string userId);

        Task<bool> AddRecipeToFavoritesAsync(string userId, int recipeId);

        Task<bool> RemoveRecipeFromFavoritesListAsync(string userId, int recipeId);
    }
}
