using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ActivityServise.Persistence.Extensions;

public static class DatabaseMigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateAsyncScope();

        using ActivityServiceDbContext productServiceDbContext =
            scope.ServiceProvider.GetRequiredService<ActivityServiceDbContext>();

        productServiceDbContext.Database.Migrate();
    }
}