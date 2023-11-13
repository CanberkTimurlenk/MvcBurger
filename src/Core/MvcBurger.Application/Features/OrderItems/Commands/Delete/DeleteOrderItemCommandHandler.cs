using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;


namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemRequest, DeleteOrderItemResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DeleteOrderItemCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<DeleteOrderItemResponse> Handle(DeleteOrderItemRequest request, CancellationToken cancellationToken)
        {
            _repositoryManager.OrderItemExtraIngredient.RemoveByOrderItemId(request.OrderItemId);
            await _repositoryManager.OrderItem.RemoveAsync(request.OrderItemId);

            return new DeleteOrderItemResponse { RowsAffected = await _repositoryManager.SaveAsync() };

        }
    }

}

