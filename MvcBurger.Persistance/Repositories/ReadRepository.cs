using MvcBurger.Application.Repositories;
using MvcBurger.Application.RequestFeatures;
using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MvcBurger.Persistance.Repositories
{
    /*
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly BurgerDbContext _context;

        public ReadRepository(BurgerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false)
        {
            var queryable = Query();

            if (IncludeSoftDeletedRecords)
                queryable = queryable.IgnoreQueryFilters();

            if (filter is not null)
                queryable = queryable.Where(filter);

            return await queryable.AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            
                queryable = queryable.Where(filter);

            return await queryable.CountAsync();

        }

        public async Task<PagedList<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> filter, RequestParameters requestParameters, bool trackChanges)

       => await GetAllByConditionAsQueryable(filter, trackChanges)
                                   .ToPagedList(requestParameters);

        public async Task<PagedList<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> filter = null, int pageNumber = 0, int pageSize = 15, bool IncludeSoftDeletedRecords = false,
            bool tracking = false)
        {
            

            if (!tracking)
                queryable.AsNoTracking();

            if (filter is not null)
                queryable.Where(filter);

            return await queryable.ToPaginatedListAsync(pageNumber, pageSize);

        }

        public async Task<TEntity?> FindAsync(string id)
        {
            return await _context.Set<TEntity>().FindAsync(Guid.Parse(id)); // TODO: check if this works
        }        

        protected IQueryable<TEntity> GetAllAsQueryable(bool trackChanges)

           => trackChanges
               ? _context.Set<TEntity>()
               : _context.Set<TEntity>().AsNoTracking();

        protected IQueryable<TEntity> GetAllByConditionAsQueryable(Expression<Func<TEntity, bool>> filter, bool trackChanges)

            => GetAllAsQueryable(trackChanges).Where(filter);
    */

}

