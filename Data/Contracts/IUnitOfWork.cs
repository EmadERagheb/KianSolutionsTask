using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Contracts
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IGenericRepository<T, TContext> GetRepository<T>() where T : BaseDomainModel;
        Task<int> SaveChangesAsync();
    }
}
