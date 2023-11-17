using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.Queries.Drinks.GetById
{
    public class GetByIdDrinkQueryHandler : IRequestHandler<GetByIdDrinkRequest, GetByIdDrinkResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetByIdDrinkQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetByIdDrinkResponse> Handle(GetByIdDrinkRequest request, CancellationToken cancellationToken)
        {
            var drink = await _repositoryManager.Drink.GetAsync(d => d.Id == request.Id);

            GetByIdDrinkResponse response = _mapper.Map<GetByIdDrinkResponse>(drink);

            return response;
        }
    }
}
