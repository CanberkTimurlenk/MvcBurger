using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Application.Repositories.ExtraIngredientMenuOrder;

namespace MvcBurger.Application.Features.OrderItemExtraIngredients.Queries.GetById
{
    public class GetByIdOrderItemExtraIngredientQueryHandler : IRequestHandler<GetByIdOrderItemExtraIngredientRequest, GetByIdOrderItemExtraIngredientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemExtraIngredientRepository _orderItemExtraIngredientRepository;

        public GetByIdOrderItemExtraIngredientQueryHandler(IMapper mapper, IOrderItemExtraIngredientRepository orderItemExtraIngredientRepository)
        {
            _mapper = mapper;
            _orderItemExtraIngredientRepository = orderItemExtraIngredientRepository;
        }

        public async Task<GetByIdOrderItemExtraIngredientResponse> Handle(GetByIdOrderItemExtraIngredientRequest request, CancellationToken cancellationToken)
        {

            return null;
            //GetByIdOrderItemExtraIngredientResponse response = _mapper.Map<GetByIdOrderItemExtraIngredientResponse>();

            //return response;
        }
    }
}
