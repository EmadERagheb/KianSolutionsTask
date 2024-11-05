using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Contracts
{
    public interface IGenericRepository<T, TContext> where T : BaseDomainModel where TContext : DbContext
    {
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(int pageNumber, int pageSize, Expression<Func<T, TResult>> selection, Expression<Func<T, bool>>? filter = default, Expression<Func<T, object>>? order = default, params string[] properties);

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>>? selection = default, Expression<Func<T, bool>>? filter = default, bool tracked = false, params string[] properties);
        Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = default);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> filter);

        Task<TResult?> GetAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>>? selection = default, bool tracked = false, params string[] properties);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);
        void Modify(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);




    }
}
