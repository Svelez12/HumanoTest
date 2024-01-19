namespace HumanoTest.Infrastructure.UnitsOfWorks;

using HumanoTest.Application.Contracts;
using HumanoTest.Domain.Contracts.IRepositories.Person;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using HumanoTest.Infrastructure.Contracts.DbContext;
using HumanoTest.Infrastructure.Repositories.Person;
using Microsoft.EntityFrameworkCore.Storage;

public class PersonUnitOfWork : IPersonUnitOfWork
{
    private readonly IHumanoTestDbContext humanoTestDbContext;
    private IPersonRepository personRepository;
    private IPersonContactRepository personContactRepository;

    public PersonUnitOfWork(IHumanoTestDbContext HumanoTestDbContext)
    {
        humanoTestDbContext = HumanoTestDbContext;
    }

    public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(humanoTestDbContext);

    public IPersonContactRepository PersonContactRepository => personContactRepository ??= new PersonContactRepository(humanoTestDbContext);

    public IDbContextTransaction BeginTransaction()
    {
        return humanoTestDbContext.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await humanoTestDbContext.Database.BeginTransactionAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            humanoTestDbContext.Dispose();
        }
    }

    public async Task<ResponseData> SaveChangesAsync()
    {
        try
        {
            await humanoTestDbContext.SaveChangesAsync();

            return new ResponseData(true, "Registro guardado satisfactoriamente.");
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error Interno.");
        }
    }
}