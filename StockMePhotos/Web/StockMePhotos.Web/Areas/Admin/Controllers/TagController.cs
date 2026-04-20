using Microsoft.AspNetCore.Mvc;
using StockMePhotos.GCommon.Exceptions;
using StockMePhotos.Services.Common.Contracts;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Web.Areas.Admin.Controllers
{
    public class TagController : BaseAdminController
    {
        private readonly ITagService tagService;
        private readonly ISlugGenerator slugGenerator;

        public TagController(ITagService tagService,
            ISlugGenerator slugGenerator)
        {
            this.tagService = tagService;
            this.slugGenerator = slugGenerator;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<TagViewModel> tagsViewModel = await tagService.GetAllTagsOrderedById();
            return View(tagsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TagFormModel formModel = new TagFormModel();
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            string slug = slugGenerator.GenerateSlug(formModel.Name);

            try
            {
                bool tagExists = await tagService.TagWithSlugExistsAsync(slug);

                if (tagExists)
                {
                    ModelState.AddModelError(string.Empty, "This tag already exists!");
                    return View(formModel);
                }

                bool hasSuccess = await tagService.CreateTagAsync(formModel, slug);

                if (!hasSuccess)
                {
                    ModelState.AddModelError(string.Empty, "Something happend! Couldn't create this tag!");
                    return View(formModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while adding a new tag!");
                return View(formModel);
            }

            return RedirectToAction("Index", "Tag", new { area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            UpdateTagFormModel? tagFormModel = await tagService.GetTagToUpdateByIdAsync(id);
            if (tagFormModel == null)
            {
                return NotFound();
            }

            return View(tagFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateTagFormModel tagFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tagFormModel);
            }

            string generatedSlug = slugGenerator.ReGenerateSlug(tagFormModel.Slug);

            try
            {
                bool hasSuccess = await tagService.UpdateTagAsync(id, generatedSlug);

                if (!hasSuccess)
                {
                    ModelState.AddModelError(string.Empty, "Unexpeted error occurred while updating tag!");
                    return View(tagFormModel);
                }
            }
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch (EntityAlreadyExistsException e)
            {
                ModelState.AddModelError(string.Empty, "This tag slug has already been used!");
                return View(tagFormModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Unexpeted error occurred while updating tag!");
                return View(tagFormModel);
            }

            return RedirectToAction("Index", "Tag", new { area = "Admin" });
        }
    }
}
