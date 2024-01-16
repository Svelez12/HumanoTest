namespace HumanoTest.Api.ConfigurationServices;

using HumanoTest.Infrastructure;
using HumanoTest.Infrastructure.Contracts.DbContext;
using Microsoft.EntityFrameworkCore;

public static class DatabaseConfigurationService
{
    public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IHumanoTestDbContext, HumanoTestDbContext>();
        services.AddDbContext<HumanoTestDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}