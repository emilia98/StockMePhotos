using Microsoft.AspNetCore.Mvc;
using StockMePhotos.GCommon.Exceptions;
using StockMePhotos.Services.Common.Contracts;
using StockMePhotos.Services.Core;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService categoryService;
        private readonly IPhotoCategoryService photoCategoryService;
        private readonly ISlugGenerator slugGenerator;

        public CategoryController(ICategoryService categoryService,
            IPhotoCategoryService photoCategoryService,
            ISlugGenerator slugGenerator)
        {
            this.categoryService = categoryService;
            this.photoCategoryService = photoCategoryService;
            this.slugGenerator = slugGenerator;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryViewModel> categoriesViewModel = await categoryService.GetAllCategoriesOrderedById();
            return View(categoriesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CategoryFormModel formModel = new CategoryFormModel();
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            string slug = slugGenerator.GenerateSlug(formModel.Name);

            try
            {
                bool categoryExists = await categoryService.CategoryWithSlugExistsAsync(slug);

                if (categoryExists)
                {
                    ModelState.AddModelError(string.Empty, "This tag already exists!");
                    return View(formModel);
                }

                bool hasSuccess = await categoryService.CreateCategoryAsync(formModel, slug);

                if (!hasSuccess)
                {
                    ModelState.AddModelError(string.Empty, "Something happend! Couldn't create this category!");
                    return View(formModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while adding a new category!");
                return View(formModel);
            }

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            UpdateCategoryFormModel? categoryFormModel = await categoryService.GetCategoryToUpdateByIdAsync(id);
            if (categoryFormModel == null)
            {
                return NotFound();
            }

            return View(categoryFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCategoryFormModel categoryFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryFormModel);
            }

            string generatedSlug = slugGenerator.ReGenerateSlug(categoryFormModel.Slug);

            try
            {
                bool hasSuccess = await categoryService.UpdateCategoryAsync(id, generatedSlug, categoryFormModel.Description);

                if (!hasSuccess)
                {
                    ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating category!");
                    return View(categoryFormModel);
                }
            }
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch (EntityAlreadyExistsException e)
            {
                ModelState.AddModelError(string.Empty, "This tag slug has already been used!");
                return View(categoryFormModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating category!");
                return View(categoryFormModel);
            }

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool categoryExists = await categoryService.CategoryWithIdExistsAsync(id);

            if (!categoryExists)
            {
                return NotFound();
            }

            IEnumerable<Guid> photosWithCategoriesAssigned = await photoCategoryService.GetAllPhotosWithCategoryAssigned(id);

            try
            {
                foreach (Guid photo in photosWithCategoriesAssigned)
                {
                    await photoCategoryService.RemoveCategoryFromPhotoAsync(photo.ToString());
                }

                await categoryService.RemoveCategoryAsync(id);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
