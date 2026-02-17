using SimpleAPI.BAL;
using SimpleAPI.Core.Models;
using SimpleAPI.DAL;
using SimpleAPI.Helpers;
using SimpleAPI.Services;

namespace SimpleAPI.Startup;

public static class OpenApiConfig
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IFizzBuzz, FizzBuzz>();
        services.AddHttpClient<IDogFactAPI, DogFactAPI>();
        // per the life cycle of the request
        //services.AddScoped<RandomNumber>();
        //New instance when something references this class
        //services.AddTransient<RandomNumber>();
        //lifecycle of application
        services.AddSingleton<RandomNumber>();
        services.AddSingleton<DogBreedIDList>();
        services.AddSingleton<FizzBuzzCache>();
    }
}
