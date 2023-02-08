using System.Text;
using Application.Common.Interfaces.Persistence;
using CA.Application.Common.Interfaces.Authentication;
using CA.Application.Common.Interfaces.Persistence.Base;
using CA.Infrastructure.DataContext;
using CA.Infrastructure.Persistence;
using CA.Infrastructure.Persistence.Base;
using Infrastructure.Persistence.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CA.Infrastructure.Authentication;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance()
            .AddDataContext(configuration);
        return services;
    }
    public static IServiceCollection AddDataContext(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<EfCoreContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
    public static IServiceCollection AddPersistance(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}
