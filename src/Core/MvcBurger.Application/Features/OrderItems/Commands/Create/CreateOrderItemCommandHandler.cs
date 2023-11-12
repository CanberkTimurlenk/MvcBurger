using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemRequest, CreateOrderItemResponse>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateOrderItemResponse> Handle(CreateOrderItemRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var orderItem = _mapper.Map<OrderItem>(request);
            
            await _orderItemRepository.AddAsync(orderItem);


            CreateOrderItemResponse createdOrderItemResponse = _mapper.Map<CreateOrderItemResponse>(orderItem);
            return createdOrderItemResponse;


        }
    }



}

