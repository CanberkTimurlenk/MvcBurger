using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Entities;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartRequest, AddToCartResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AddToCartCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<AddToCartResponse> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {


            var order = await _repositoryManager.Order.Get(o => o.AppUserId.Equals(request.AppUserId) && o.OrderStatus == OrderStatus.Cart);

            if (order is null)
            {
                var createdOrder = new Order
                {

                    Id = Guid.NewGuid(),
                    AppUserId = request.AppUserId,
                    OrderStatus = OrderStatus.Cart,
                    OrderItems = request.OrderItemRequest.Select(oi =>
                    {

                        var orderItemId = Guid.NewGuid();

                        return new OrderItem
                        {
                            Id = orderItemId,
                            Amount = oi.Amount,
                            DrinkId = oi.DrinkId,
                            MenuId = oi.MenuId,
                            Size = oi.Size,
                            OrderId = Guid.NewGuid(),
                            OrderItemExtraIngredient = oi.ExtraIngredientId?.Select(
                            oi => new OrderItemExtraIngredient()
                            {
                                Id = Guid.NewGuid(),
                                ExtraIngredientId = oi,
                                OrderItemId = orderItemId

                            }).ToList()
                        };
                    }).ToList()

                };
                await _repositoryManager.Order.AddAsync(createdOrder);
            }

            else
            {
                foreach (var item in request.OrderItemRequest)
                {
                    var orderItemId = Guid.NewGuid();
                    var orderItem = new OrderItem
                    {
                        Id = orderItemId,
                        Amount = item.Amount,
                        DrinkId = item.DrinkId,
                        MenuId = item.MenuId,
                        Size = item.Size,
                        OrderId = order.Id,
                        OrderItemExtraIngredient = item?.ExtraIngredientId?.Select(
                                                       oi => new OrderItemExtraIngredient
                                                       {
                                                           Id = Guid.NewGuid(),
                                                           ExtraIngredientId = oi,
                                                           OrderItemId = orderItemId

                                                       }).ToList()

                    };                                        
                    await _repositoryManager.OrderItem.AddAsync(orderItem);                    
                }
            }
            await _repositoryManager.SaveAsync();
            var cart = await _repositoryManager.Order.GetCartByUserId(request.AppUserId);
            return new AddToCartResponse { Cart = cart };

        }
    }



}




