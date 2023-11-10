using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Queries.Drinks.GetAllDrinks
{
    public class GetAllDrinksQueryHandler : IRequestHandler<GetAllDrinksQueryRequest, IEnumerable<GetAllDrinksQueryResponse>>
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;

        public GetAllDrinksQueryHandler(IDrinkRepository drinkRepository, IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllDrinksQueryResponse>> Handle(GetAllDrinksQueryRequest request, CancellationToken cancellationToken)
        {
            var drinks = await _drinkRepository.GetAllExpression(tracking: false);
            var mappedDrinks = _mapper.Map<IEnumerable<GetAllDrinksQueryResponse>>(drinks);
            return mappedDrinks;

        }
    }
}
