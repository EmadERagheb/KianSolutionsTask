using Data.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Data.Repositories
{
    public class GenericRepository<T, TContext>(TContext context) : IGenericRepository<T, TContext> where T : BaseDomainModel where TContext : DbContext
    {
        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.AddRange(entities);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(int pageNumber, int pageSize, Expression<Func<T, TResult>> selection, Expression<Func<T, bool>>? filter = default, Expression<Func<T, object>>? order = default, params string[] properties)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            if (order is not null)
            {
                query = query.OrderByDescending(order);
            }
           
            query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            if (typeof(T) != typeof(TResult))
            {
                return await query.Select(selection).ToListAsync();
            }
            IQueryable<TResult> resultQuery = (IQueryable<TResult>)query;
            return await resultQuery.ToListAsync();

        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>>? selection=default, Expression<Func<T, bool>>? filter=default, bool tracked = false, params string[] properties)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
  

            foreach (var property in properties)
            {
                query = query.Include(property);
                 

            }

            if (tracked)
                query = query.AsTracking();
            if (typeof(T) != typeof(TResult)&& selection is not null)
            {
                return await query.Select(selection).ToListAsync();
            }
            IQueryable<TResult> resultQuery = (IQueryable<TResult>)query;
            return await resultQuery.ToListAsync();
        }

        public async Task<TResult?> GetAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>>? selection = default, bool tracked = false, params string[] properties)
        {
            IQueryable<T> query = context.Set<T>().Where(filter);
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            if (tracked)
            {
                query = query.AsTracking();
            }
            if (typeof(TResult) != typeof(T)&& selection is not null)
            {
                return await query.Select(selection).FirstOrDefaultAsync();

            }
            IQueryable<TResult> resultQuery = (IQueryable<TResult>)query;
            return await resultQuery.FirstOrDefaultAsync();

        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = default)
        {
            IQueryable<T> query = context.Set<T>();
            if (filter is not null)
                query = query.Where(filter);
            return await query.CountAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().AnyAsync(filter);
        }

        public void Modify(T entity)
        {
            context.Update(entity);
        }

        public void Remove(T entity)
        {
            context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.RemoveRange(entities);
        }


    
    
    }
}
