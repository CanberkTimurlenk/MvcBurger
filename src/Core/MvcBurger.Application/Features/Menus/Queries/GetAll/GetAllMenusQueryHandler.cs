using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.Menus.Queries.GetAll
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusRequest, GetAllMenusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetAllMenusQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetAllMenusResponse> Handle(GetAllMenusRequest request, CancellationToken cancellationToken)
        {
            var menus = await _repositoryManager.Menu.GetAllAsync();
            var mappedMenus = _mapper.Map<IEnumerable<GetAllMenuResponseListItem>>(menus);

            return new GetAllMenusResponse { List = mappedMenus };

        }
    }
}
