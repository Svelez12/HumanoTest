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
using HumanoTest.Application.Models.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
{
    private readonly IHumanoTestDbContext _context;

    public GenericRepository(IHumanoTestDbContext humanoTestDbContext)
    {
        _context = humanoTestDbContext;
    }

    public async Task<ResponseData> GetAllDataAsync<TResult>(
        int page,
        int take,
        Expression<Func<T, TResult>> select,
        Expression<Func<T, bool>> whereCondition = null,
        List<WhereIfModel<T>> whereif = null,
        params Expression<Func<T, object>>[] includes)
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

        if (whereif != null)
        {
            foreach (WhereIfModel<T> item in whereif)
            {
                if (item.Condition)
                {
                    query = query.Where(item.Predicate);
                }
            }
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

            return new ResponseData(true, "Registro Guardado de Satisfactoriamente.", entity.Id);
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error interno.");
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
            return new ResponseData(false, $"Error interno.");
        }
    }

    public async Task<ResponseData> UpdateAsync(T entity, params string[] propertiesToExcludeFromUpdate)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;

            if (propertiesToExcludeFromUpdate != null)
            {
                foreach (string propertiy in propertiesToExcludeFromUpdate)
                {
                    _context.Entry(entity).Property(propertiy).IsModified = false;
                }
            }

            return new ResponseData(true, "Registro actualizado satisfactoriamente.");
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error al actualizar registro: {ex.Message}");
        }
    }

    public async Task<ResponseData> DeleteAsync(T entity)
    {
        try
        {
            if (await ExistAsync(entity.Id))
            {
                _context.Set<T>().Remove(entity);

                return new ResponseData(true, "Registro eliminado satisfactoriamente.");
            }
            else
            {
                return new ResponseData(false, "Registro no encontrado.");
            }
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error al eliminar registro: {ex.Message}");
        }
    }

    public async Task<ResponseData> DeleteRangeAsync(params T[] entities)
    {
        try
        {
            _context.Set<T>().RemoveRange(entities);

            return new ResponseData(true, "Registros eliminados satisfactoriamente.");
        }
        catch (Exception ex)
        {
            return new ResponseData(false, $"Error al eliminar registros: {ex.Message}");
        }
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.Set<T>().AnyAsync(e => e.Id == id);
    }
}