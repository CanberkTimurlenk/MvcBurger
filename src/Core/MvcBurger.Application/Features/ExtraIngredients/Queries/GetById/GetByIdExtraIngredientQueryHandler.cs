using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.Queries.ExtraIngredients.GetById
{
    public class GetByIdExtraIngredientQueryHandler : IRequestHandler<GetByIdExtraIngredientRequest, GetByIdExtraIngredientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetByIdExtraIngredientQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetByIdExtraIngredientResponse> Handle(GetByIdExtraIngredientRequest request, CancellationToken cancellationToken)
        {
            var extraIngredient = await _repositoryManager.ExtraIngredient.Get(ei => ei.Id == request.Id);

            GetByIdExtraIngredientResponse response = _mapper.Map<GetByIdExtraIngredientResponse>(extraIngredient);

            return response;
        }
    }
}
