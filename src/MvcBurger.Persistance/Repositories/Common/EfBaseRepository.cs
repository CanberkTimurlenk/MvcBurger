using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MvcBurger.Application.Contracts.Repositories.Common;

namespace MvcBurger.Persistance.Repositories.Common
{

    public abstract class EfBaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {

        private readonly BurgerDbContext _context;

        protected DbSet<TEntity> Table => _context.Set<TEntity>();

        public EfBaseRepository(BurgerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().AnyAsync(filter);

        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().CountAsync(filter);

        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await Table.ToListAsync();

            else
                return await Table.Where(filter).ToListAsync();

        }

        public async Task<TEntity?> FindAsync(Guid id)
        {
            return await Table.FindAsync(id); // TODO: check if this works
        }

        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await Table.FirstOrDefaultAsync(filter);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {

            await _context.AddRangeAsync(entities);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var entity = await FindAsync(id);

            if (entity is not null)
                Table.Remove(entity);

        }

        public void Remove(TEntity id)
        {
            Table.Remove(id);
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);

        }
    }
}

