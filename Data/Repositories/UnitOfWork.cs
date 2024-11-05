using Data.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Data.Repositories
{
    public class UnitOfWork<TContext>(TContext context) : IUnitOfWork<TContext> where TContext : DbContext
    {
        private Hashtable? _repositories;

        public void Dispose()
        {
            context.Dispose();

        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        public IGenericRepository<T, TContext> GetRepository<T>() where T : BaseDomainModel
        {
            if (_repositories is null) _repositories = new Hashtable();
            var type = typeof(T);
            var contextType = typeof(TContext);
            if (!_repositories.ContainsKey($"{contextType.Name} - {type.Name}"))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var reposatoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(type, contextType), context);
                _repositories[$"{contextType.Name} - {type.Name}"] = reposatoryInstance;
            }
            return (IGenericRepository<T, TContext>)_repositories[$"{contextType.Name} - {type.Name}"]!;
        }


    }


}
