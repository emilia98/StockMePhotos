using Microsoft.AspNetCore.Mvc;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IEnumerable<TagListViewModel> allTags = await this.tagService
                .ListAsync();

            return this.View(allTags);
        }

        [HttpGet]
        public IActionResult Add()
        {
            TagFormInputModel inputModel = new TagFormInputModel();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TagFormInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                // TODO: Check for duplicating slugs -> lowercase
                await this.tagService.AddAsync(inputModel);
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                TagUpdateInputModel? inputModel = await this.tagService.GetUpdateDetailsByIdAsync(id);
                if (inputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(inputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(TagUpdateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.tagService.UpdateAsync(inputModel);
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return this.View();
        }
    }
}