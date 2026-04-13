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
    public class PhotoController : BaseController
    {
        private readonly IPhotoService photoService;
        private readonly ICategoryService categoryService;
        private readonly IPhotoUploadService photoUploadService;
        private readonly IPhotoCategoryService photoCategoryService;
        private readonly IFavoritePhotoService favoritePhotoService;
        private readonly CloudinaryService cloudinaryService;


        public PhotoController(
            IPhotoService photoService,
            ICategoryService categoryService,
            IPhotoUploadService photoUploadService,
            IPhotoCategoryService photoCategoryService,
            IFavoritePhotoService favoritePhotoService,
            CloudinaryService cloudinaryService)
        {
            this.photoService = photoService;
            this.categoryService = categoryService;
            this.photoUploadService = photoUploadService;
            this.photoCategoryService = photoCategoryService;
            this.favoritePhotoService = favoritePhotoService;
            this.cloudinaryService = cloudinaryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PhotoViewModel> viewModel = await this.photoService
                .GetAll();
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction(nameof(Index));
            }

            string? userId = GetUserId();
            PhotoDetailsViewModel? viewModel = await this.photoService.GetDetails(id, userId);
            if (viewModel == null)
            {
                return NotFound();
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddPhotoInputModel inputModel = new AddPhotoInputModel();
            inputModel.Categories = await this.categoryService.ListAllCategories();
            return View(inputModel);
        }

        [HttpPost]
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

            string userId = GetUserId()!;

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
                await this.photoCategoryService.AddCategoryToPhotoAsync(photoId.ToString(), categoryId);
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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            string userId = GetUserId()!;
            string? creatorId = await this.photoService.GetPhotoOwnerByPhotoIdAsync(id);

            if (string.IsNullOrEmpty(creatorId) || userId != creatorId)
            {
                return RedirectToAction(nameof(Details), new { id = id });
            }

            try
            {
                bool deletePhotoSuccess = await this.photoService.DeletePhotoByIdAsync(id);

                if (deletePhotoSuccess)
                {
                    await this.photoUploadService.RemovePhotoUploadAsync(id);
                    await this.photoCategoryService.RemoveCategoryFromPhotoAsync(id);

                    return RedirectToAction(nameof(MyPhotos));
                }

                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            UpdatePhotoInputModel? inputModel = await this.photoService.GetEntityToUpdateByIdAsync(id);
            if (inputModel == null)
            {
                return RedirectToAction(nameof(MyPhotos));
            }

            string? userId = GetUserId();
            string creatorId = inputModel.UserId;

            // If the current user is not the creator
            if (creatorId != userId)
            {
                return RedirectToAction(nameof(MyPhotos));
            }

            inputModel.Categories = await this.categoryService.ListAllCategories();
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UpdatePhotoInputModel inputModel)
        {
            UpdatePhotoInputModel? oldInputModel = await this.photoService.GetEntityToUpdateByIdAsync(id);
            if (inputModel == null)
            {
                return RedirectToAction(nameof(MyPhotos));
            }

            string userId = GetUserId()!;
            // string? ownerId = await this.photoService.GetPhotoOwnerByPhotoIdAsync(id);
            string? ownerId = oldInputModel!.UserId;
            if (ownerId == null || ownerId != userId)
            {
                return RedirectToAction(nameof(MyPhotos));
            }

            inputModel.Categories = await this.categoryService.ListAllCategories();
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            int oldCategory = oldInputModel.CategoryId;
            int newCategory = inputModel.CategoryId;
            bool isValidCategory = inputModel.Categories.Any(c => c.Id == newCategory);
            if (!isValidCategory)
            {
                ModelState.AddModelError(nameof(inputModel.CategoryId), CategoryNotFound);
                return View(inputModel);
            }

            try
            {
                if (newCategory != oldCategory)
                {
                    await this.photoCategoryService.RemoveCategoryFromPhotoAsync(id);
                    await this.photoCategoryService.AddCategoryToPhotoAsync(id, newCategory);
                }

                bool updateSucess = await this.photoService.UpdatePhotoEntity(id, inputModel);
                if (updateSucess)
                {
                    return RedirectToAction(nameof(Details), new { id = id });
                }

                return RedirectToAction(nameof(MyPhotos));

                // If new photo is added
                // Remove the old photo
                // Add the new photo
                // Guid photoId = await this.photoService.AddNewPhoto(inputModel, userId);
                // if 
                // await this.photoCategoryService.AddCategoryToPhotoAsync(photoId, categoryId);
                // string uploadImageUrl = await this.cloudinaryService.UploadImageAsync(image!);
                // await this.photoUploadService.AddPhotoUploadAsync(photoId, uploadImageUrl);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ModelState.AddModelError(string.Empty, "Error occurred while trying to update the photo!");
                inputModel.Categories = await this.categoryService.ListAllCategories();
                return View(inputModel);
                throw;
            }
        }

        [HttpGet]
        [Route("Photo/My")]
        public async Task<IActionResult> MyPhotos()
        {
            string userId = GetUserId()!;
            IEnumerable<PhotoViewModel> photosByUser = await this.photoService.GetAllPhotosByUserAsync(userId);
            MyPhotosListViewModel viewModel = new MyPhotosListViewModel()
            {
                AllPhotos = photosByUser
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(string id)
        {
            string userId = GetUserId()!;
            string? ownerId = await this.photoService.GetPhotoOwnerByPhotoIdAsync(id);

            if (ownerId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ownerId == userId)
            {
                return RedirectToAction(nameof(MyPhotos));
            }

            try
            {
                await this.favoritePhotoService.AddPhotoToFavorites(id, userId);
                return RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(string id)
        {
            string userId = GetUserId()!;
            string? ownerId = await this.photoService.GetPhotoOwnerByPhotoIdAsync(id);

            if (ownerId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ownerId == userId)
            {
                return RedirectToAction(nameof(MyPhotos));
            }

            try
            {
                await this.favoritePhotoService.RemovePhotoFromFavorites(id, userId);
                return RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            string userId = GetUserId()!;
            IEnumerable<PhotoViewModel> favoritePhotosByUser = await this.favoritePhotoService.GetAllFavoritePhotosByUserAsync(userId);
            MyPhotosListViewModel viewModel = new MyPhotosListViewModel()
            {
                AllPhotos = favoritePhotosByUser
            };

            return View(viewModel);
        }
    }
}
