using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.SauceOrders.Commands.Create
{
    public class CreateSauceOrderCommandHandler : IRequestHandler<CreateSauceOrderRequest, CreateSauceOrderResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateSauceOrderCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
           

        }

        public async Task<CreateSauceOrderResponse> Handle(CreateSauceOrderRequest request, CancellationToken cancellationToken)
        {
            var souceOrder = _mapper.Map<SauceOrder>(request);

            await _repositoryManager.SauceOrder.AddAsync(souceOrder);
            await _repositoryManager.SaveAsync();

            CreateSauceOrderResponse createdSauceOrderResponse = _mapper.Map<CreateSauceOrderResponse>(souceOrder);
            return createdSauceOrderResponse;

        }
    }
}

