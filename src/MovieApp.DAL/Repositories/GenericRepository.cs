using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Repositories;
using MovieApp.DAL.Contexts;
using System.Linq.Expressions;

namespace MovieApp.DAL.Repositories
{
    public class GenericRepository<TEntity> : lGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext contexts) 
        {
            this.context = context;
        }
        public DbSet<TEntity> Table => context.Set<TEntity>();

        public async Task<int> CommitAsnyc ()
            => await context.SaveChangesAsync();


        public async Task CreateAsync(TEntity entity)
        
         =>   await Table.AddAsync(entity);
           
        

        public void Delete(TEntity entity)
        
          =>  Table.Remove(entity);
        

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>>? expression = null, bool asNoTracking = false, params string[] includes)
        { 
            var query = Table.AsQueryable();
            if (includes.Length > 0) 
            {
              foreach (var include in includes) 
              {
                query = query.Include(include);
              }

            }
            query = asNoTracking == true 
                ? query.AsNoTracking() 
                : query;

            return expression is not null 
                ? query.Where(expression) 
                : query;
        }


        public async Task<TEntity> GetByIdAsnyc(int id)
            => await Table.FindAsync(id);
    }
}
