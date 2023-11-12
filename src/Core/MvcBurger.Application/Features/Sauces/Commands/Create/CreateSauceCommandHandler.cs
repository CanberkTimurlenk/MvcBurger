using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateSauceCommandHandler : IRequestHandler<CreateSauceRequest, CreateSauceResponse>
    {
        private readonly ISauceRepository _sauceRepository;
        private readonly IMapper _mapper;

        public CreateSauceCommandHandler(ISauceRepository sauceRepository, IMapper mapper)
        {
            _sauceRepository = sauceRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateSauceResponse> Handle(CreateSauceRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var sauce = _mapper.Map<Sauce>(request);
            sauce.Id = Guid.NewGuid();

            await _sauceRepository.AddAsync(sauce);


            CreateSauceResponse createdSauceReponse = _mapper.Map<CreateSauceResponse>(sauce);
            return createdSauceReponse;
        }
    }
}

