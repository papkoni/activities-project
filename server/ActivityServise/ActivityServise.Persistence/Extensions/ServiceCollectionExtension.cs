using ActivityServise.Application.Abstractions.DB;
using ActivityServise.Persistence.Abstractions;
using ActivityServise.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ActivityServise.Persistence.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<IActivityServiceDbContext,ActivityServiceDbContext>(
            options =>
            {
                var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") 
                                       ?? configuration.GetConnectionString("ActivityServiceDbContext");
                options.UseNpgsql(connectionString);
            }
        );
    }
}