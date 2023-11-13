using Microsoft.EntityFrameworkCore;
using MvcBurger.Application.Contracts.Repositories.OrderItems;
using MvcBurger.Domain.Entities;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    public class OrderItemRepository : EfBaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly BurgerDbContext _context;
        public OrderItemRepository(BurgerDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<OrderItem?> FindAsync(Guid id)
        {
            return await _context.OrderItems
                .Include(oi => oi.OrderItemExtraIngredient)
                .FirstOrDefaultAsync(x => x.Id == id);
        }




    }
}