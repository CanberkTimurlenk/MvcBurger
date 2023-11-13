using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemRequest, DeleteOrderItemResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<DeleteOrderItemResponse> Handle(CreateOrderItemRequest request, CancellationToken cancellationToken)
        {

            var orderItem = _mapper.Map<OrderItem>(request);

            await _repositoryManager.OrderItem.AddAsync(orderItem);
            await _repositoryManager.SaveAsync();

            DeleteOrderItemResponse createdOrderItemResponse = _mapper.Map<DeleteOrderItemResponse>(orderItem);
            return createdOrderItemResponse;

        }
    }



}

