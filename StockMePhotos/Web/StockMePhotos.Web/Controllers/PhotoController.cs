using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMePhotos.GCommon;
using StockMePhotos.Services.Common;
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
        private readonly IPhotoUploadService photoUploadService;
        private readonly IPhotoCategoryService photoCategoryService;
        private readonly CloudinaryService cloudinaryService;


        public PhotoController(
            IPhotoService photoService,
            ICategoryService categoryService,
            IPhotoUploadService photoUploadService,
            IPhotoCategoryService photoCategoryService,
            CloudinaryService cloudinaryService)
        {
            this.photoService = photoService;
            this.categoryService = categoryService;
            this.photoUploadService = photoUploadService;
            this.photoCategoryService = photoCategoryService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PhotoViewModel> viewModel = await this.photoService
                .GetAll();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction(nameof(Index));
            }

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            PhotoDetailsViewModel? viewModel = await this.photoService.GetDetails(id, userId);
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.View(viewModel);
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
                Guid photoId = await this.photoService.AddNewPhoto(inputModel, userId);
                await this.photoCategoryService.AddCategoryToPhotoAsync(photoId, categoryId);
                string uploadImageUrl = await this.cloudinaryService.UploadImageAsync(image!);
                await this.photoUploadService.AddPhotoUploadAsync(photoId, uploadImageUrl);
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

        [HttpGet]
        [Route("Photo/My")]
        [Authorize]
        public async Task<IActionResult> MyPhotos()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            IEnumerable<PhotoViewModel> photosByUser = await this.photoService.GetAllPhotosByUserAsync(userId);
            MyPhotosListViewModel viewModel = new MyPhotosListViewModel()
            {
                AllPhotos = photosByUser
            };
            return View(viewModel);
        }
    }
}
