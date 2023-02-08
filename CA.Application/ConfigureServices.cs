using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace CA.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ConfigureServices).Assembly);
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}

