using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Persistance.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        //
        private readonly BurgerDbContext _context;

        public WriteRepository(BurgerDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                entity.CreatedDate = DateTime.UtcNow;

            await _context.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Guid.Parse(id));
            return await _context.SaveChangesAsync() > 0;
        }

        public TEntity UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Set<TEntity>().Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }
    }
}
