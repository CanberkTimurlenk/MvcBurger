using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;

namespace MvcBurger.Application.Features.Menus.Queries.GetById
{
    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuRequest, GetByIdMenuResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public GetByIdMenuQueryHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<GetByIdMenuResponse> Handle(GetByIdMenuRequest request, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.Get(m => m.Id.Equals(request.Id));

            GetByIdMenuResponse response = _mapper.Map<GetByIdMenuResponse>(menu);
            return response;
        }
    }
}
