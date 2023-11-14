using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Exceptions.NotFoundException;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem
{
    public class DeleteExtraIngredientCommandHandler : IRequestHandler<DeleteExtraIngredientRequest, DeleteExtraIngredientResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DeleteExtraIngredientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<DeleteExtraIngredientResponse> Handle(DeleteExtraIngredientRequest request, CancellationToken cancellationToken)
        {

            await _repositoryManager.ExtraIngredient.RemoveByIdAsync(request.ExtraIngredientId);
            await _repositoryManager.SaveAsync();

            return new DeleteExtraIngredientResponse();

        }
    }

}




