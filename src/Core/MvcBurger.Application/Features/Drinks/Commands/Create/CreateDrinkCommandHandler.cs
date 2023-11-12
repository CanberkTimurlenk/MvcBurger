using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateDrinkCommandHandler : IRequestHandler<CreateDrinkRequest, CreateDrinkResponse>
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;

        public CreateDrinkCommandHandler(IDrinkRepository drinkRepository, IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateDrinkResponse> Handle(CreateDrinkRequest request, CancellationToken cancellationToken)
        {

            
            var drink = _mapper.Map<Drink>(request);
            drink.Id = Guid.NewGuid();

            await _drinkRepository.AddAsync(drink);


            CreateDrinkResponse createdDrinkResponse = _mapper.Map<CreateDrinkResponse>(drink);
            return createdDrinkResponse;


        }
    }



}

