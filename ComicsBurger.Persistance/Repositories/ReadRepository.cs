using ComicsBurger.Application.Repositories;
using ComicsBurger.Domain.Entities.Common;
using ComicsBurger.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ComicsBurger.Persistance.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly BurgerDbContext _context;

        public ReadRepository(BurgerDbContext context)
        {
            _context = context;
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            
                            
            if (IncludeSoftDeletedRecords)
                queryable = _context.IgnoreQueryFilters();
            
            if (filter is not null)
                queryable = queryable.Where(filter);

            return await.AnyAsync();

        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll(bool IncludeSoftDeletedRecords = false, bool tracking = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false, bool tracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(string id, bool IncludeSoftDeletedRecords, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false, bool tracking = false)
        {
            throw new NotImplementedException();
        }
    }
}
