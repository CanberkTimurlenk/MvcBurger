using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Queries.Drinks.GetById
{
    public class GetByIdDrinksQueryHandler : IRequestHandler<GetByIdDrinksQueryRequest, GetByIdDrinksQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrinkRepository _drinkRepository;

        public GetByIdDrinksQueryHandler(IMapper mapper, IDrinkRepository drinkRepository)
        {
            _mapper = mapper;
            _drinkRepository = drinkRepository;
        }

        public async Task<GetByIdDrinksQueryResponse> Handle(GetByIdDrinksQuery request, CancellationToken cancellationToken)
        {
            var drink = await _drinkRepository.GetSingleAsync(d => d.Id == request.Id);

            GetByIdDrinksQueryResponse response = _mapper.Map<GetByIdDrinksQueryResponse>(drink);

            return response;
        }
    }
}
