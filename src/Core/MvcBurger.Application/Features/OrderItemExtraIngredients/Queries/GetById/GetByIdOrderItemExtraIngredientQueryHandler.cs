using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.OrderItemExtraIngredients.Queries.GetById
{
    public class GetByIdOrderItemExtraIngredientQueryHandler : IRequestHandler<GetByIdOrderItemExtraIngredientRequest, GetByIdOrderItemExtraIngredientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetByIdOrderItemExtraIngredientQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetByIdOrderItemExtraIngredientResponse> Handle(GetByIdOrderItemExtraIngredientRequest request, CancellationToken cancellationToken)
        {

            return null;
            //GetByIdOrderItemExtraIngredientResponse response = _mapper.Map<GetByIdOrderItemExtraIngredientResponse>();

            //return response;
        }
    }
}
