using ComicsBurger.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ComicsBurger.Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IQueryable<TEntity> GetAll(bool IncludeSoftDeletedRecords = false, bool tracking = false);
        IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false, bool tracking = false);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false, bool tracking = false);
        Task<TEntity> GetByIdAsync(string id, bool IncludeSoftDeletedRecords, bool tracking = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false);


    }
}
