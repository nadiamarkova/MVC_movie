using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Text.Json;

namespace MvcMovie.Controllers;

// HomeController here is a class
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // _httpClient is name of variable and HttpClient is the type of that variable
    // Here we are just declaring the _httpClient variable, but have not assigned it a value yet (it is still null)
    // a nullable type means you can set them to null, it's expected (in addition to the other types it can have)
    private readonly HttpClient _httpClient;

    // HomeController is a constructor
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // here we assign a value to the variable _httpClient
        // new HttpClient is calling the HttpClient constructor
        _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Index()
    {     
        DogApiModel? dogApiResponse = await GetDogApiResponse();
        return View(dogApiResponse);
    }

    // here below we are declaring the GetDogApiResponse() method that we are assigning as value of dogImageResponse variable above
    // it is returning a Task of type DogApiModel
    private async Task<DogApiModel?> GetDogApiResponse()
    {
        // here we declare a variable called response and assign it a value which is the output of GetStringAsync() which is type string.
        string response = await _httpClient.GetStringAsync("https://dog.ceo/api/breeds/image/random");

        // JsonSerializer is a class, and inside that class is a method called Deserialize.
        // response is a json string, and it gets converted into the DogApiModel TYPE.

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        DogApiModel? dogApiModel = JsonSerializer.Deserialize<DogApiModel>(response, options);
        return dogApiModel;
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

