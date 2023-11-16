using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll
{
    public class GetAllExtraIngredientsQueryHandler : IRequestHandler<GetAllExtraIngredientsRequest, GetAllExtraIngredientsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetAllExtraIngredientsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetAllExtraIngredientsResponse> Handle(GetAllExtraIngredientsRequest request, CancellationToken cancellationToken)
        {
            var allExtraIngredients = await _repositoryManager.ExtraIngredient.GetAllAsync();

            var responseList = _mapper.Map<IEnumerable<GetAllExtraIngredientResponseListItem>>(allExtraIngredients);

            return new GetAllExtraIngredientsResponse
            {
                List = responseList
            };
        }
    }
}
