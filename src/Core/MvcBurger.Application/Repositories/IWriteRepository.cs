using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Application.Repositories
{
    public interface IWriteRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        public Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> AddAsync(TEntity entity);
        public Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> RemoveAsync(string id);
        public TEntity UpdateAsync(TEntity entity);
    }
}
