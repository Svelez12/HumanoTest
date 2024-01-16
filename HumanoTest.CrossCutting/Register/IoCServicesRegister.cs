namespace HumanoTest.CrossCutting.Register;

using HumanoTest.CrossCutting.Register.Person;
using Microsoft.Extensions.DependencyInjection;

public static class IoCServicesRegister
{
    public static void AddRegistration(this IServiceCollection services)
    {
        IoCPersonServicesRegister.AddRegistration(services);
    }
}