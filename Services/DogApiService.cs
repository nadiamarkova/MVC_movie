using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MvcMovie.Models;

// the Controller will call this Service to make updates to the Model / get stuff from the API
// The Service is the layer between the Controller and the data retrieval method (could be API or database)
// The Controller uses the Service to get data

namespace MvcMovie.Services
{
    public class DogApiService
    {
        private readonly HttpClient _httpClient;

        public DogApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DogApiModel> GetRandomDogImageAsync()
        {
            var response = await _httpClient.GetStringAsync("https://dog.ceo/api/breeds/image/random");
            return JsonConvert.DeserializeObject<DogApiModel>(response);
        }
    }
}
