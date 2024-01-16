namespace HumanoTest.CrossCutting.Register;

using HumanoTest.CrossCutting.Register.Person;
using Microsoft.Extensions.DependencyInjection;

public static class IoCRepositoriesRegister
{
    public static void AddRegistration(this IServiceCollection services)
    {
        IoCPersonRepositoriesRegister.AddRegistration(services);
    }
}