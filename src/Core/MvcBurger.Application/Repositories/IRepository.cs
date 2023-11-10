using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Paging;
using System.Linq.Expressions;

namespace MvcBurger.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        Task<PagedList<TEntity>> GetAllExpression(Expression<Func<TEntity, bool>> filter = null,
            bool tracking = false);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = false);
        Task<TEntity> GetByIdAsync(Guid id); // TODO: check 
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Query();

        public Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> AddAsync(TEntity entity);
        public Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> RemoveAsync(string id);
        public TEntity UpdateAsync(TEntity entity);




    }
}
