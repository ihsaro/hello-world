using Microsoft.Extensions.DependencyInjection;
using HIT.Domain.Repositories;
using HIT.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HIT.Infrastructure.Repositories;
using HIT.Infrastructure.Persistence.Repositories;

namespace HIT.Infrastructure;

public static class InfrastructureDependencyResolver
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            /*
            options.UseNpgsql(configuration.GetConnectionString("HITDatabase"), x =>
            {
                x.MigrationsAssembly("HIT.Infrastructure");
            });
            */
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            options.UseSqlite($"Data Source={System.IO.Path.Join(path, "hit.db")}", x =>
            {
                x.MigrationsAssembly("HIT.Infrastructure");
            });
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}