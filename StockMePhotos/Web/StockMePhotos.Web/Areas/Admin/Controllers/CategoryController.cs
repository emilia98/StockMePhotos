using Microsoft.AspNetCore.Mvc;
using StockMePhotos.Services.Common.Contracts;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService categoryService;
        private readonly ISlugGenerator slugGenerator;

        public CategoryController(ICategoryService categoryService,
            ISlugGenerator slugGenerator)
        {
            this.categoryService = categoryService;
            this.slugGenerator = slugGenerator;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryViewModel> categoriesViewModel = await categoryService.GetAllCategoriesOrderedById();
            return View(categoriesViewModel);
        }
    }
}
