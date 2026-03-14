using Microsoft.AspNetCore.Mvc;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Photo;

namespace StockMePhotos.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService photoService;

        public PhotoController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PhotoViewModel> viewModel = await this.photoService
                .GetAll();
            return View(viewModel);
        }
    }
}
