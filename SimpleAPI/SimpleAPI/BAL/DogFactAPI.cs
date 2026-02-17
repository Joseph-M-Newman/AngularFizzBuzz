using SimpleAPI.Core.Models;
using System.Text.Json;

namespace SimpleAPI.BAL
{
    public class DogFactAPI : IDogFactAPI
    {
        private readonly HttpClient _httpClient;

        public DogFactAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DogAPIResponse> GetBreedAsync(string breedID)
        {
            var apiResponse = await _httpClient.GetAsync($"https://dogapi.dog/api/v2/breeds/{breedID}");
            var content = await apiResponse.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(content);
            var root = doc.RootElement;

            return new DogAPIResponse(
                root.GetProperty("data").GetProperty("id").GetString(), 
                root.GetProperty("data").GetProperty("attributes").GetProperty("name").GetString(), 
                root.GetProperty("data").GetProperty("attributes").GetProperty("life").GetProperty("min").GetInt32(),
                root.GetProperty("data").GetProperty("attributes").GetProperty("life").GetProperty("max").GetInt32(),
                root.GetProperty("data").GetProperty("attributes").GetProperty("male_weight").GetProperty("min").GetInt32(), 
                root.GetProperty("data").GetProperty("attributes").GetProperty("male_weight").GetProperty("max").GetInt32(), 
                root.GetProperty("data").GetProperty("attributes").GetProperty("female_weight").GetProperty("max").GetInt32(), 
                root.GetProperty("data").GetProperty("attributes").GetProperty("female_weight").GetProperty("max").GetInt32(),
                root.GetProperty("data").GetProperty("attributes").GetProperty("description").GetString());

        }
    }
}
