using SimpleAPI.Services;

namespace SimpleAPI.Startup;

public static class OpenApiConfig
{
    public static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<INumberValidate, NumberValidate>();
    }
}
