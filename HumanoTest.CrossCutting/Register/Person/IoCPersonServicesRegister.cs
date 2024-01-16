namespace HumanoTest.CrossCutting.Register.Person;

using HumanoTest.Application.Contracts.IServices.Person;
using HumanoTest.Application.Services.Person;
using Microsoft.Extensions.DependencyInjection;

public static class IoCPersonServicesRegister
{
    public static void AddRegistration(this IServiceCollection services)
    {
        AddRegisterServices(services);
    }

    private static void AddRegisterServices(IServiceCollection services)
    {
        //Person.
        services.AddScoped<IPersonService, PersonService>();
    }
}