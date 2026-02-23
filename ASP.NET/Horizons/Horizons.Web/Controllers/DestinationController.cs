using System.Xml;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Humanizer.DateTimeHumanizeStrategy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.T4Templating;
using static Horizons.GCommon.ValidationConstatnts.Destination;

namespace Horizons.Web.Controllers
{
    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;
        private readonly ITerrainService terrainService;

        public DestinationController(IDestinationService destinationService, ITerrainService terrainService)
        {
            this.destinationService = destinationService;
            this.terrainService = terrainService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = GetUserId();

                IEnumerable<DestinationIndexViewModel> allDestinations = await this.destinationService
                    .GetAllDestinationsAsync(userId);

                return View(allDestinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = GetUserId();

                DestinationDetailsViewModel? detailsViewModel = await this.destinationService
                    .GetDestinationDetailsAsync(id, userId);

                if (detailsViewModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return View(detailsViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                AddDestinationInputModel inputModel = new AddDestinationInputModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(PublishedOnFormat),
                    Terrains = await this.terrainService.GetTerrainsDropdownDataAsync(),
                };

                return View(inputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    inputModel.Terrains = await this.terrainService.GetTerrainsDropdownDataAsync();
                    return View(inputModel);
                }

                bool addResult = await this.destinationService
                    .AddDestinationAsync(this.GetUserId()!, inputModel);

                if (addResult == false)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occurred while adding a destination");
                    inputModel.Terrains = await this.terrainService.GetTerrainsDropdownDataAsync();
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                EditDestinationInputModel? editInputModel = await this.destinationService
                    .GetDestinationForEditingAsync(userId, id);

                if (editInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                editInputModel.Terrains = await this.terrainService
                    .GetTerrainsDropdownDataAsync();

                return View(editInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDestinationInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(inputModel);
                }

                bool editResult = await this.destinationService
                    .PersistUpdateDestinationAsync(this.GetUserId()!, inputModel);

                if (editResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while updating the destination!");

                    return View(inputModel);
                }

                return this.RedirectToAction(nameof(Details), new { id = inputModel.Id });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                DeleteDestinationInputModel? deleteModel = await this.destinationService
                    .GetDestinationForDeletingAsync(userId, id);

                if (deleteModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return View(deleteModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDestinationInputModel? inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Please do not modify the page");
                    return this.View(inputModel);
                }

                bool deleteResult = await this.destinationService
                    .SoftDeleteDestinationAsync(this.GetUserId()!, inputModel);

                if (deleteResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while deleting the destination!");

                    return View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = this.GetUserId()!;

                IEnumerable<FavoriteDestinationViewModel>? favoriteDestination = await this.destinationService
                    .GetUserFavoriteDestinationsAsync(userId);

                if(favoriteDestination == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favoriteDestination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;


                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool favAddResult = await this.destinationService
                    .AddDestinationToUserFavoritesListAsync(userId, id.Value);

                if(favAddResult == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            try
            {
                string? userId = this.GetUserId()!;

                if (userId == null)
                {
                    return this.Forbid();
                }

                bool result = await this.destinationService.RemoveDestinationFromFavoriteAsync(userId, id);

                if (result == false)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

    }
}
