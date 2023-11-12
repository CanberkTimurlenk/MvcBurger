using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories.MenuOrders;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Orders.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var order = _mapper.Map<Order>(request);
            order.Id = Guid.NewGuid();

            await _orderRepository.AddAsync(order);


            CreateOrderResponse createdOrderResponse = _mapper.Map<CreateOrderResponse>(order);
            return createdOrderResponse;


        }
    }



}

