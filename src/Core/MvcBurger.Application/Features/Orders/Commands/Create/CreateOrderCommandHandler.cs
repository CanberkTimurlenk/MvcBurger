using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Orders.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
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

            await _repositoryManager.Order.AddAsync(order);
            await _repositoryManager.SaveAsync();


            CreateOrderResponse createdOrderResponse = _mapper.Map<CreateOrderResponse>(order);
            return createdOrderResponse;


        }
    }



}

