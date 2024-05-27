using System.Diagnostics.CodeAnalysis;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Repository.Orm.Abstract.Contexts;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Infra.Data.Repository.Orm.Contexts;
using MicroErp.Infra.Data.Repository.Orm.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using DbContext = MicroErp.Infra.Data.Repository.Orm.Contexts.DbContext;

namespace MicroErp.Infra.Bootstrap.Database;

[ExcludeFromCodeCoverage]
public static class Startup
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<IDbContext, DbContext>(
            opt =>
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(configuration["ConnectionStrings:Connection"])
        );

        services.AddDbContext<DbContextUser>(
          opt =>
              opt.UseSqlServer(configuration["ConnectionStrings:Connection"])
                  .EnableSensitiveDataLogging()
        );

        services.AddIdentity<User, Roles>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 50;

            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;

        }).AddEntityFrameworkStores<DbContextUser>()
          .AddDefaultTokenProviders();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://microerp.solutions",
                ValidAudience = "MicroErp.RefreshToken.API"
            };
        });

        services.AddAuthorization();
        services.AddMemoryCache();
        services.AddJwksManager().PersistKeysInMemory().UseJwtValidation();

        services.AddEndpointsApiExplorer();

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        return services;
    }
}