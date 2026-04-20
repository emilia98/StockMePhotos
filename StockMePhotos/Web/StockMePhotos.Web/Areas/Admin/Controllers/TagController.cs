using Microsoft.AspNetCore.Mvc;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Tag;

namespace StockMePhotos.Web.Areas.Admin.Controllers
{
    public class TagController : BaseAdminController
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<TagViewModel> tagsViewModel = await tagService.GetAllTagsOrderedById();
            return View(tagsViewModel);
        }
    }
}
