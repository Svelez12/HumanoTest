namespace HumanoTest.Domain.Contracts.UnitsOfWorks;

using HumanoTest.Application.Contracts;
using HumanoTest.Domain.Contracts.IRepositories.Person;
using Microsoft.EntityFrameworkCore.Storage;

public interface IPersonUnitOfWork : IDisposable
{
    Task<ResponseData> SaveChangesAsync();

    IDbContextTransaction BeginTransaction();

    Task<IDbContextTransaction> BeginTransactionAsync();

    public IPersonRepository PersonRepository { get; }

    public IPersonContactRepository PersonContactRepository { get; }
}