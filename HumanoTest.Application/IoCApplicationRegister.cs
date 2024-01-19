namespace HumanoTest.Application;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class IoCApplicationRegister
{
    public static void AddRegistration(this IServiceCollection services)
    {
        // Event handlers
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}