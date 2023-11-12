using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Queries.Drinks.GetById
{
    public class GetByIdDrinkQueryHandler : IRequestHandler<GetByIdDrinkRequest, GetByIdDrinkResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDrinkRepository _drinkRepository;

        public GetByIdDrinkQueryHandler(IMapper mapper, IDrinkRepository drinkRepository)
        {
            _mapper = mapper;
            _drinkRepository = drinkRepository;
        }

        public async Task<GetByIdDrinkResponse> Handle(GetByIdDrinkRequest request, CancellationToken cancellationToken)
        {
            var drink = await _drinkRepository.Get(d => d.Id == request.Id);

            GetByIdDrinkResponse response = _mapper.Map<GetByIdDrinkResponse>(drink);

            return response;
        }
    }
}
