using Microsoft.EntityFrameworkCore;
using MvcBurger.Application.Contracts.Repositories.Orders;
using MvcBurger.Application.DTOs.Cart;
using MvcBurger.Domain.Entities;
using MvcBurger.Domain.Enums;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Persistance.Repositories.Common;

namespace MvcBurger.Persistance.Repositories
{
    public class OrderRepository : EfBaseRepository<Order>, IOrderRepository
    {
        private readonly BurgerDbContext _context;
        public OrderRepository(BurgerDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<CartDto?> GetCartByUserId(string appUserId)
        {

            return await Table.Where(o => o.AppUserId == appUserId && o.OrderStatus == OrderStatus.Cart) //&& o.OrderStatus == OrderStatus.Cart)
                              .Include(o => o.OrderItems)
                              .ThenInclude(orderItem => orderItem.Drink)
                              .Include(o => o.OrderItems)
                              .ThenInclude(oi => oi.OrderItemExtraIngredient)
                              .ThenInclude(menuIngredient => menuIngredient.ExtraIngredient)
                              .Include(o => o.OrderItems)
                              .ThenInclude(orderItem => orderItem.Menu)
                              .Select(o => new CartDto
                              {
                                  TotalPrice = o.TotalPrice,
                                  CartItems = o.OrderItems.Select(oi => new CartItemDto
                                  {
                                      Id = oi.Id,
                                      Size = oi.Size,
                                      Menu = new MenuDto { Id = oi.Menu.Id, Name = oi.Menu.Name, Price = oi.Menu.Price },
                                      Drink = new DrinkDto { Id = oi.Id, Name = oi.Menu.Name },
                                      ExtraIngredients = oi.OrderItemExtraIngredient.Select(oi => oi.ExtraIngredient).Select(OrderItemExtraIngredient => new ExtraIngredientDto
                                      {
                                          Id = OrderItemExtraIngredient.Id,
                                          Name = OrderItemExtraIngredient.Name,
                                          Price = OrderItemExtraIngredient.Price
                                      }).ToList()

                                  })
                              }).FirstOrDefaultAsync();
        }
    }
}
