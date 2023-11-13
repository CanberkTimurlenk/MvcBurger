using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.Menus;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.Menus.Queries.GetById
{
    public class GetByIdMenuQueryHandler : IRequestHandler<GetByIdMenuRequest, GetByIdMenuResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetByIdMenuQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetByIdMenuResponse> Handle(GetByIdMenuRequest request, CancellationToken cancellationToken)
        {
            var menu = await _repositoryManager.Menu.Get(m => m.Id.Equals(request.Id));

            GetByIdMenuResponse response = _mapper.Map<GetByIdMenuResponse>(menu);
            return response;
        }
    }
}
