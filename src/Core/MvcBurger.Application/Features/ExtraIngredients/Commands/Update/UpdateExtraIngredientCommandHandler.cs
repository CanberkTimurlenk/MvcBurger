using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Exceptions.NotFoundException;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.ExtraIngredients.Commands.Update
{
    public class UpdateExtraIngredientCommandHandler : IRequestHandler<UpdateExtraIngredientRequest, UpdateExtraIngredientResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateExtraIngredientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;

        }

        public async Task<UpdateExtraIngredientResponse> Handle(UpdateExtraIngredientRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<UpdateExtraIngredientRequest, ExtraIngredient>(request);

            var extraIngredient = await _repositoryManager.ExtraIngredient.FindAsync(request.Id);

            _mapper.Map(request, extraIngredient);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<UpdateExtraIngredientResponse>(extraIngredient);


        }
    }

}




