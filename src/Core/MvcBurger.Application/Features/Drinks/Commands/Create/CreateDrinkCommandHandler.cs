using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Pipelines.Logging;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateDrinkCommandHandler : IRequestHandler<CreateDrinkRequest, CreateDrinkResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateDrinkCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CreateDrinkResponse> Handle(CreateDrinkRequest request, CancellationToken cancellationToken)
        {
            var drink = _mapper.Map<Drink>(request);
            drink.Id = Guid.NewGuid();

            await _repositoryManager.Drink.AddAsync(drink);
            await _repositoryManager.SaveAsync();


            CreateDrinkResponse createdDrinkResponse = _mapper.Map<CreateDrinkResponse>(drink);
            return createdDrinkResponse;


        }
    }



}

