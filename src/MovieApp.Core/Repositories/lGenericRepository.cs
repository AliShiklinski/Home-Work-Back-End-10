using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using System.Linq.Expressions;

namespace MovieApp.Core.Repositories
{
    public interface lGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get;  }

        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params string[] includes);

        Task<TEntity> GetByIdAsnyc(int id);

        Task<int> CommitAsnyc();
    }
}
