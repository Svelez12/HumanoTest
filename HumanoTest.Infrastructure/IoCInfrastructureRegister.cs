namespace HumanoTest.Infrastructure;

using HumanoTest.Domain.Contracts.IRepositories.Person;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using HumanoTest.Infrastructure.Repositories.Person;
using HumanoTest.Infrastructure.UnitsOfWorks;
using Microsoft.Extensions.DependencyInjection;

public static class IoCInfrastructureRegister
{
    public static void AddRegistration(this IServiceCollection services)
    {
        AddRegisterRepositories(services);
        services.AddRegistrationUnitOfWorks();
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

    public static void AddRegistrationUnitOfWorks(this IServiceCollection services)
    {
        //Person.
        services.AddTransient<IPersonUnitOfWork, PersonUnitOfWork>();
    }
}