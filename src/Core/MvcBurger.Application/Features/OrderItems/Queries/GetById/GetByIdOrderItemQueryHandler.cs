using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.OrderItems.Queries.GetById
{
    public class GetByIdOrderItemQueryHandler : IRequestHandler<GetByIdOrderItemRequest, GetByIdOrderItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetByIdOrderItemQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetByIdOrderItemResponse> Handle(GetByIdOrderItemRequest request, CancellationToken cancellationToken)
        {

            var orderItem = await _repositoryManager.OrderItem.FindAsync(request.Id);

            GetByIdOrderItemResponse response = _mapper.Map<GetByIdOrderItemResponse>(orderItem);

            return response;
        }
    }
}
