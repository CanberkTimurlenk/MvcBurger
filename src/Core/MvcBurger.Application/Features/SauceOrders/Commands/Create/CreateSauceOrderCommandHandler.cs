using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.SauceOrders.Commands.Create
{
    public class CreateSauceOrderCommandHandler : IRequestHandler<CreateSauceOrderRequest, CreateSauceOrderResponse>
    {
        private readonly ISauceOrderRepository _sauceOrderRepository;
        private readonly IMapper _mapper;

        public CreateSauceOrderCommandHandler(ISauceOrderRepository sauceOrderRepository, IMapper mapper)
        {
            _sauceOrderRepository = sauceOrderRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateSauceOrderResponse> Handle(CreateSauceOrderRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var souceOrder = _mapper.Map<SauceOrder>(request);
            
            await _sauceOrderRepository.AddAsync(souceOrder);

            CreateSauceOrderResponse createdSauceOrderResponse = _mapper.Map<CreateSauceOrderResponse>(souceOrder);
            return createdSauceOrderResponse;

        }
    }
}

