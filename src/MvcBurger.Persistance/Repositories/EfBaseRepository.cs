using MvcBurger.Application.Repositories;
using MvcBurger.Application.RequestFeatures;
using MvcBurger.Domain.Entities.Common;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MvcBurger.Persistance.Repositories
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

        public async Task<TEntity?> FindAsync(string id)
        {
            return await Table.FindAsync(Guid.Parse(id)); // TODO: check if this works
        }

        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await Table.FirstOrDefaultAsync(filter);
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {

            await _context.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await FindAsync(id);
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public TEntity UpdateAsync(TEntity entity)
        {

            Table.Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }


    }
}

