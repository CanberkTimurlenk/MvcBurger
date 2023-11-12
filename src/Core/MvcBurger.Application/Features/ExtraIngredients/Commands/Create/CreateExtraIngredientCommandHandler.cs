using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateExtraIngredientCommandHandler : IRequestHandler<CreateExtraIngredientRequest, CreateExtraIngredientResponse>
    {
        private readonly IExtraIngredientRepository _extraIngredientRepository;
        private readonly IMapper _mapper;

        public CreateExtraIngredientCommandHandler(IExtraIngredientRepository extraIngredientRepository, IMapper mapper)
        {
            _extraIngredientRepository = extraIngredientRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateExtraIngredientResponse> Handle(CreateExtraIngredientRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var extraIngredient = _mapper.Map<ExtraIngredient>(request);
            extraIngredient.Id = Guid.NewGuid();

            await _extraIngredientRepository.AddAsync(extraIngredient);


            CreateExtraIngredientResponse createdExtraIngredientResponse = _mapper.Map<CreateExtraIngredientResponse>(extraIngredient);
            return createdExtraIngredientResponse;


        }
    }



}

