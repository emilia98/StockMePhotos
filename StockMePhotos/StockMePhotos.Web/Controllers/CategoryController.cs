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

        [HttpGet]
        public IActionResult Add()
        {
            CategoryFormInputModel inputModel = new CategoryFormInputModel();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryFormInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.categoryService.AddAsync(inputModel);
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
