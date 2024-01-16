namespace HumanoTest.Infrastructure.Repositories.Generic;

using HumanoTest.Application.Contracts;
using HumanoTest.Domain.Entities;
using HumanoTest.Infrastructure.Contracts.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Services.Common.Paging;
using HumanoTest.Domain.Contracts.IRepositories.Generic;
using System.Resources;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
{
    private readonly IHumanoTestDbContext _context;

    public GenericRepository(IHumanoTestDbContext humanoTestDbContext)
    {
        _context = humanoTestDbContext;
    }

    public async Task<ResponseData> GetAllDataAsync<TResult>(int page, int take, Expression<Func<T, TResult>> select, Expression<Func<T, bool>> whereCondition = null, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
        {
            foreach (Expression<Func<T, object>> item in includes)
            {
                query = query.Include(item).AsNoTracking();
            }
        }

        if (whereCondition != null)
        {
            query = query.Where(whereCondition);
        }

        if (select == null)
        {
            return new ResponseData(true, await query.ToListAsync());
        }

        return new ResponseData(true, await query.OrderByDescending(c => c.Id).Select(select).GetPagedAsync(page, take));
    }

    public virtual async Task<ResponseData> CreateAsync(T entity)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return new ResponseData(true, "Registro Guardado de Satisfactoriamente.", entity.Id);
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error interno {ex}");
        }
    }

    public async Task<ResponseData> AddRangeAsync(IEnumerable<T> entity)
    {
        try
        {
            await _context.Set<T>().AddRangeAsync(entity);

            await _context.SaveChangesAsync();

            return new ResponseData(true, "Registro Guardado de Satisfactoriamente.");
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error interno {ex}");
        }
    }
}