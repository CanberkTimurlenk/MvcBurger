using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll
{
    public class GetAllExtraIngredientsQueryHandler : IRequestHandler<GetAllExtraIngredientsRequest, GetAllExtraIngredientsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExtraIngredientRepository _extraIngredientRepository;

        public GetAllExtraIngredientsQueryHandler(IMapper mapper, IExtraIngredientRepository extraIngredientRepository)
        {
            _mapper = mapper;
            _extraIngredientRepository = extraIngredientRepository;
        }


        public async Task<GetAllExtraIngredientsResponse> Handle(GetAllExtraIngredientsRequest request, CancellationToken cancellationToken)
        {
            var allExtraIngredients = await _extraIngredientRepository.GetAll();

            var responseList = _mapper.Map<IEnumerable<GetAllExtraIngredientResponseListItem>>(allExtraIngredients);

            return new GetAllExtraIngredientsResponse
            {
                List = responseList
            };
        }
    }
}
