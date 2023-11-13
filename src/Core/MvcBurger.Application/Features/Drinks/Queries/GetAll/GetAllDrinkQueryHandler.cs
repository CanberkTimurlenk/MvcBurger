using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Features.Menus.Queries.GetAll;

namespace MvcBurger.Application.Features.Queries.Drinks.GetAll
{
    public class GetAllDrinksQueryHandler : IRequestHandler<GetAllDrinksRequest, GetAllDrinksResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllDrinksQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetAllDrinksResponse> Handle(GetAllDrinksRequest request, CancellationToken cancellationToken)
        {
            var drinks = await _repositoryManager.Drink.GetAll();
            var mappedDrinks = _mapper.Map<IEnumerable<GetAllDrinksResponseListItem>>(drinks);

            return new GetAllDrinksResponse { List = mappedDrinks };

        }
    }
}
