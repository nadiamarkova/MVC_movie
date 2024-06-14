using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MvcMovie.Services;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class DogApiController : Controller
    {
        private readonly DogApiService _dogApiService;

        public DogController(DogApiService dogApiService)
        {
            _dogApiService = dogApiService;
        }

        public async Task<IActionResult> Index()
        {
            var dogImageResponse = await _dogApiService.GetRandomDogImageAsync();
            return View(dogImageResponse);
        }
    }
}
