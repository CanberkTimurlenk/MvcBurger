using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Features.Drinks.Commands.Delete;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem
{
    public class DeleteDrinkCommandHandler : IRequestHandler<DeleteDrinkRequest, DeleteDrinkResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DeleteDrinkCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            

        }

        public async Task<DeleteDrinkResponse> Handle(DeleteDrinkRequest request, CancellationToken cancellationToken)
        {

            await _repositoryManager.Drink.RemoveByIdAsync(request.DrinkId);
            await _repositoryManager.SaveAsync();

            return new DeleteDrinkResponse();

        }
    }

}




