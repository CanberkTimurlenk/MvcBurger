using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Paging;
using System.Linq.Expressions;

namespace MvcBurger.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> FindAsync(string id); // TODO: check 
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);



        public Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> AddAsync(TEntity entity);
        public Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> RemoveAsync(string id);
        public TEntity UpdateAsync(TEntity entity);




    }
}
