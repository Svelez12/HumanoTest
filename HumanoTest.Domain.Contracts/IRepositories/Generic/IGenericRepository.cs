namespace HumanoTest.Domain.Contracts.IRepositories.Generic;

using HumanoTest.Application.Contracts;
using System.Linq.Expressions;

public interface IGenericRepository<T> where T : class
{

    /// <summary>
    /// Get All Register.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="page"></param>
    /// <param name="take"></param>
    /// <param name="select"></param>
    /// <param name="whereCondition"></param>
    /// <param name="includes"></param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> GetAllDataAsync<TResult>(int page, int take, Expression<Func<T, TResult>> select,
                                                Expression<Func<T, bool>> whereCondition = null,
                                                params Expression<Func<T, object>>[] includes);

    /// <summary>
    /// Add Register.
    /// </summary>
    /// <param name="entity"> Nombre de Entidad a Registrar. </param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> CreateAsync(T entity);

    /// <summary>
    /// Add Range of Register.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> AddRangeAsync(IEnumerable<T> entity);
}