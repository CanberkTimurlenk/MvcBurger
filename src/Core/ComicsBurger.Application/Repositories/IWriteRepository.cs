using ComicsBurger.Domain.Entities.Common;
using System.Buffers.Text;

namespace ComicsBurger.Application.Repositories
{
    public interface IWriteRepository<T> 
        where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(ICollection<T> datas);
        bool Remove(T model);
        bool RemoveRange(ICollection<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
