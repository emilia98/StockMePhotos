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

        public async Task<IActionResult> Index()
        {
            IEnumerable<TagViewModel> allTagsViewModel = await tagService
                .GetAllTagsOrderedByName();
            return View(allTagsViewModel);
        }
    }
}
