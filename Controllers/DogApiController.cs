using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MvcMovie.Services;
using MvcMovie.Models;
using Newtonsoft.Json;

namespace MvcMovie.Controllers
{
    public class DogApiController : Controller
    {
       /// I added the HttpClient outside of the public DogApiController(). And that got rid of the error.
       /// Not sure if I need something in the DogApiController() constructor.
       /// Now the issue is I don't know what to replace the dogApiService with on line 24, since we got rid of the Service.

        private readonly HttpClient _httpClient;

        public DogApiController()
        {
        
        }

        public async Task<IActionResult> Index()
        {
            var dogImageResponse = await GetRandomDogImageAsync();
            return View(dogImageResponse);
        }

        public async Task<DogApiModel> GetRandomDogImageAsync()
        {
            var response = await _httpClient.GetStringAsync("https://dog.ceo/api/breeds/image/random");
            return JsonConvert.DeserializeObject<DogApiModel>(response);
        }    
    }
}