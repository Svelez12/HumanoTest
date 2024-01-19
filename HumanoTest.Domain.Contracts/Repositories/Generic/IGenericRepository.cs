namespace HumanoTest.Domain.Contracts.IRepositories.Generic;

using HumanoTest.Application.Contracts;
using System.Linq.Expressions;
using HumanoTest.Application.Models.Common;

public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Get All Register.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="page">Page Number</param>
    /// <param name="take"></param>
    /// <param name="select">Select</param>
    /// <param name="whereCondition">Where Condition</param>
    /// <param name="whereif"></param>
    /// <param name="includes">Entities to Include</param>
    /// /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> GetAllDataAsync<TResult>(int page, int take, Expression<Func<T, TResult>> select,
                                                Expression<Func<T, bool>> whereCondition = null,
                                                List<WhereIfModel<T>> whereif = null,
                                                params Expression<Func<T, object>>[] includes);

    /// <summary>
    /// Add Register.
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> CreateAsync(T entity);

    /// <summary>
    /// Add Range of Register.
    /// </summary>
    /// <param name="entity"><see cref="T"/>Entity</param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> AddRangeAsync(IEnumerable<T> entity);

    /// <summary>
    /// Update a Register.
    /// </summary>
    /// <param name="entity"><see cref="T"/>Entity</param>
    /// <param name="propertiesToExcludeFromUpdate"></param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> UpdateAsync(T entity, params string[] propertiesToExcludeFromUpdate);

    /// <summary>
    /// Delete a Register.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> DeleteAsync(T entity);

    /// <summary>
    /// Delete a Registers Range.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<ResponseData> DeleteRangeAsync(params T[] entities);

    /// <summary>
    /// Result Contain Any Elements Validation.
    /// </summary>
    /// <param name="id">Id Of Entity</param>
    /// <returns><see cref="bool"/>True or False</returns>
    Task<bool> ExistAsync(int id);
}