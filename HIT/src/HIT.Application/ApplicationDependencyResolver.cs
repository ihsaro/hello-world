using System.Reflection;
using HIT.Application.Services;
using HIT.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HIT.Application;

public static class ApplicationDependencyResolver
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddTransient<ICandidateService, CandidateService>();

        return services;
    }
}