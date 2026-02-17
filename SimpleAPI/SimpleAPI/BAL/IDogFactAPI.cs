using SimpleAPI.Core.Models;

namespace SimpleAPI.BAL
{
    public interface IDogFactAPI
    {
        //Notes: Task -> Async
        Task<DogAPIResponse> GetBreedAsync(string breedID);
    }
}
