using System.Reflection;

namespace HIT.REST.Routes.Configuration;

internal static class RouteConfigurationExtensions
{
    internal static void AddRouteConfigurations(this IServiceCollection services)
    {
        var routeConfigurations = new List<IRoute>();

        routeConfigurations
                        .AddRange(Assembly
                        .GetExecutingAssembly()
                        .ExportedTypes
                        .Where(x => typeof(IRoute).IsAssignableFrom(x) && x.IsClass && x.IsSealed)
                        .Select(Activator.CreateInstance).Cast<IRoute>()
        );

        services.AddSingleton(routeConfigurations as IReadOnlyCollection<IRoute>);
    }

    internal static void UseRouteConfigurations(this WebApplication app)
    {
        app.Services.GetRequiredService<IReadOnlyCollection<IRoute>>().ToList().ForEach(route =>
        {
            route.ConfigureRoutes(app);
        });
    }
}