using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateMenuOrderCommandHandler : IRequestHandler<CreateMenuOrderRequest, CreateMenuOrderResponse>
    {
        private readonly IMenuOrderRepository _menuOrderRepository;
        private readonly IMapper _mapper;

        public CreateMenuOrderCommandHandler(IMenuOrderRepository menuOrderRepository, IMapper mapper)
        {
            _menuOrderRepository = menuOrderRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateMenuOrderResponse> Handle(CreateMenuOrderRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var menuOrder = _mapper.Map<OrderItem>(request);
            
            await _menuOrderRepository.AddAsync(menuOrder);


            CreateMenuOrderResponse createdMenuOrderResponse = _mapper.Map<CreateMenuOrderResponse>(menuOrder);
            return createdMenuOrderResponse;


        }
    }



}

