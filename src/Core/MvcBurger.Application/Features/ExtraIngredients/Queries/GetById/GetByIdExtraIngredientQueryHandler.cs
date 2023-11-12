using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Queries.ExtraIngredients.GetById
{
    public class GetByIdExtraIngredientQueryHandler : IRequestHandler<GetByIdExtraIngredientRequest, GetByIdExtraIngredientResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExtraIngredientRepository _extraIngredientRepository;

        public GetByIdExtraIngredientQueryHandler(IMapper mapper, IExtraIngredientRepository extraIngredientRepository)
        {
            _mapper = mapper;
            _extraIngredientRepository = extraIngredientRepository;
        }

        public async Task<GetByIdExtraIngredientResponse> Handle(GetByIdExtraIngredientRequest request, CancellationToken cancellationToken)
        {
            var extraIngredient = await _extraIngredientRepository.Get(ei => ei.Id == request.Id);

            GetByIdExtraIngredientResponse response = _mapper.Map<GetByIdExtraIngredientResponse>(extraIngredient);

            return response;
        }
    }
}
