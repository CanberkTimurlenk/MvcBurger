using MvcBurger.Application.Contracts.Repositories.Common;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Contracts.Repositories.OrderItems
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }
}
