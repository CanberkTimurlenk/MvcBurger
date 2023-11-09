using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Paging;
using System.Linq.Expressions;

namespace MvcBurger.Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<PagedList<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, int index = 0, int size = 15, bool IncludeSoftDeletedRecords = false,
            bool tracking = false);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false, bool tracking = false);
        Task<TEntity> GetByIdAsync(string id); // TODO: check 
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter, bool IncludeSoftDeletedRecords = false);

        IQueryable<TEntity> Query();


    }
}
