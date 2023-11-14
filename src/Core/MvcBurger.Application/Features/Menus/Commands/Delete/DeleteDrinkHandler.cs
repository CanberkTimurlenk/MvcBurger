using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.Menus.Commands.Delete
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuRequest, DeleteMenuResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DeleteMenuCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<DeleteMenuResponse> Handle(DeleteMenuRequest request, CancellationToken cancellationToken)
        {

            await _repositoryManager.Menu.RemoveByIdAsync(request.MenuId);
            await _repositoryManager.SaveAsync();

            return new DeleteMenuResponse();

        }
    }

}




