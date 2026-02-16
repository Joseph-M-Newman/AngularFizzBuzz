using SimpleAPI.BAL;
using SimpleAPI.DAL;
using SimpleAPI.Services;

namespace SimpleAPI.Startup;

public static class OpenApiConfig
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IFizzBuzz, FizzBuzz>();
        // per the life cycle of the request
        //services.AddScoped<RandomNumber>();
        //New instance when something references this class
        //services.AddTransient<RandomNumber>();
        //lifecycle of application
        services.AddSingleton<RandomNumber>();
        services.AddSingleton<FizzBuzzCache>();
    }
}
