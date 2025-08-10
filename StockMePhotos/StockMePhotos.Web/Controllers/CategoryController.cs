using Microsoft.AspNetCore.Mvc;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IEnumerable<CategoryListViewModel> allCategories = await this.categoryService
                .ListAllAsync();

            return this.View(allCategories);
        }
    }
}
