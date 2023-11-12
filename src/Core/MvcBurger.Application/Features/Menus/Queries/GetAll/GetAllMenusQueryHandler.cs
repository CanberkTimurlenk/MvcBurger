using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Menus.Queries.GetAll
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusRequest, GetAllMenusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public GetAllMenusQueryHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<GetAllMenusResponse> Handle(GetAllMenusRequest request, CancellationToken cancellationToken)
        {
            var menus = await _menuRepository.GetAll();
            var mappedMenus = _mapper.Map<IEnumerable<GetAllMenuResponseListItem>>(menus);

            return new GetAllMenusResponse { List = mappedMenus };

        }
    }
}
