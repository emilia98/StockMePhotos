using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMePhotos.GCommon;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Photo;
using System.Security.Claims;
using static StockMePhotos.GCommon.ValidationMessages.Photo;

namespace StockMePhotos.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService photoService;
        private readonly ICategoryService categoryService;

        public PhotoController(
            IPhotoService photoService,
            ICategoryService categoryService)
        {
            this.photoService = photoService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PhotoViewModel> viewModel = await this.photoService
                .GetAll();
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            AddPhotoInputModel inputModel = new AddPhotoInputModel();
            inputModel.Categories = await this.categoryService.ListAllCategories();
            return View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddPhotoInputModel inputModel)
        {
            inputModel.Categories = await this.categoryService.ListAllCategories();
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            int categoryId = inputModel.CategoryId;
            bool isValidCategory = inputModel.Categories.Any(c => c.Id == categoryId);
            if (!isValidCategory)
            {
                ModelState.AddModelError(nameof(inputModel.CategoryId), CategoryNotFound);
                return View(inputModel);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            IFormFile? image = inputModel.Image;
            string? imageError = null;
            bool isValidImage = ImageChecker.IsValidImage(image, out imageError);
            if (!isValidImage)
            {
                ModelState.AddModelError(nameof(inputModel.Image), imageError ?? "Unknown image error");
                return View(inputModel);
            }

            try
            {
                await this.photoService.AddNewPhoto(inputModel, userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ModelState.AddModelError(string.Empty, "Error occurred while trying to add new photo!");
                return View(inputModel);
                throw;
            }

            return this.RedirectToAction(nameof(Index));

        }
    }
}
