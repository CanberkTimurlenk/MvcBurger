using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Features.Commands.Menus.Create;
using MvcBurger.Application.Pipelines.Logging;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Menus.Create
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuRequest, CreateMenuResponse>, ILoggableRequest
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }


        public async Task<CreateMenuResponse> Handle(CreateMenuRequest request, CancellationToken cancellationToken)
        {

            var menu = _mapper.Map<Menu>(request);
            menu.Id = Guid.NewGuid();

            await _repositoryManager.Menu.AddAsync(menu);
            await _repositoryManager.SaveAsync();


            CreateMenuResponse createMenuResponse = _mapper.Map<CreateMenuResponse>(menu);
            return createMenuResponse;

        }
    }

}

