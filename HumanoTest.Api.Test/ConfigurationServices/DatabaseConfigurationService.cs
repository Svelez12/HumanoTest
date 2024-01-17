namespace HumanoTest.Api.Tests.ConfigurationServices;

using HumanoTest.Infrastructure;
using HumanoTest.Infrastructure.Contracts.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DatabaseConfigurationService
{
    public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IHumanoTestDbContext, HumanoTestDbContext>();
        services.AddDbContext<HumanoTestDbContext>(options =>
          options.UseInMemoryDatabase("DataTest"));
    }
}