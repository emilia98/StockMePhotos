using Microsoft.AspNetCore.Mvc;
using StockMePhotos.Services.Core.Interfaces;
using StockMePhotos.ViewModels.Home;
using StockMePhotos.ViewModels.Photo;
using StockMePhotos.Web.Models;
using System.Diagnostics;

namespace StockMePhotos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoService photoService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IPhotoService photoService,
            ILogger<HomeController> logger)
        {
            this.photoService = photoService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PhotoViewModel> topPhotos = await this.photoService
                .GetTopPhotos(3);
            IEnumerable<PhotoViewModel> latestPhotos = await this.photoService
                .GetLatestPhotos(3);
            IndexViewModel viewModel = new IndexViewModel
            {
                TopPhotos = topPhotos,
                LatestPhotos = latestPhotos
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
