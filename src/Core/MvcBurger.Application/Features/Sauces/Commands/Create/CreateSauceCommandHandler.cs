using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Contracts.Repositories.Sauces;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateSauceCommandHandler : IRequestHandler<CreateSauceRequest, CreateSauceResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateSauceCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            

        }

        public async Task<CreateSauceResponse> Handle(CreateSauceRequest request, CancellationToken cancellationToken)
        {



            var sauce = _mapper.Map<Sauce>(request);
            sauce.Id = Guid.NewGuid();

            await _repositoryManager.Sauce.AddAsync(sauce);
            await _repositoryManager.SaveAsync();


            CreateSauceResponse createdSauceReponse = _mapper.Map<CreateSauceResponse>(sauce);
            return createdSauceReponse;
        }
    }
}

