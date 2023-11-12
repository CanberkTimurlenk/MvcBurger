using AutoMapper;
using MediatR;
using MvcBurger.Application.Features.Menus.Queries.GetAll;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Queries.Drinks.GetAll
{
    public class GetAllDrinksQueryHandler : IRequestHandler<GetAllDrinksRequest, GetAllDrinksResponse>
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;

        public GetAllDrinksQueryHandler(IDrinkRepository drinkRepository, IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }

        public async Task<GetAllDrinksResponse> Handle(GetAllDrinksRequest request, CancellationToken cancellationToken)
        {
            var drinks = await _drinkRepository.GetAll();
            var mappedDrinks = _mapper.Map<IEnumerable<GetAllDrinksResponseListItem>>(drinks);

            return new GetAllDrinksResponse { List = mappedDrinks };

        }
    }
}
