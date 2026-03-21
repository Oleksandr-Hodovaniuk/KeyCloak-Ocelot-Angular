using Microsoft.EntityFrameworkCore;

namespace Products;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen();

        return services;
    }
}