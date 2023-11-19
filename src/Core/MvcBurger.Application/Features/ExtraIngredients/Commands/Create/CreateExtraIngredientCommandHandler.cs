using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateExtraIngredientCommandHandler : IRequestHandler<CreateExtraIngredientRequest, CreateExtraIngredientResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateExtraIngredientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
          

        }

        public async Task<CreateExtraIngredientResponse> Handle(CreateExtraIngredientRequest request, CancellationToken cancellationToken)
        {



            var extraIngredient = _mapper.Map<ExtraIngredient>(request);
            extraIngredient.Id = Guid.NewGuid();

            await _repositoryManager.ExtraIngredient.AddAsync(extraIngredient);
            await _repositoryManager.SaveAsync();


            CreateExtraIngredientResponse createdExtraIngredientResponse = _mapper.Map<CreateExtraIngredientResponse>(extraIngredient);
            return createdExtraIngredientResponse;


        }
    }



}

