using Application.Data;
using Domain.EmicionesCarbono;
using Domain.Primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var ConexionString = configuration.GetConnectionString("MySQL");
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(ConexionString, ServerVersion.AutoDetect(ConexionString)));

        services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IEmisionCarbonoRepository, EmisionCarbonoRepository>();

        return services;
    }
}