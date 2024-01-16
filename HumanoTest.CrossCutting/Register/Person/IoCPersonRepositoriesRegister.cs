namespace HumanoTest.CrossCutting.Register.Person;

using HumanoTest.Domain.Contracts.IRepositories.Person;
using HumanoTest.Infrastructure.Repositories.Person;
using Microsoft.Extensions.DependencyInjection;

public static class IoCPersonRepositoriesRegister
{
    public static void AddRegistration(this IServiceCollection services)
    {
        AddRegisterRepositories(services);
    }

    /// <summary>
    /// Agregar Registro de Repositorios.
    /// </summary>
    /// <param name="services"> Repositorio. </param>
    private static void AddRegisterRepositories(IServiceCollection services)
    {
        //Person
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPersonContactRepository, PersonContactRepository>();
    }
}