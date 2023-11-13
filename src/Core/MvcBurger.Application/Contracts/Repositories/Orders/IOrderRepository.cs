using MvcBurger.Application.Contracts.Repositories.Common;
using MvcBurger.Application.DTOs.Cart;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Contracts.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<CartDto?> GetCartByUserId(string AppUserId);
    }
}
