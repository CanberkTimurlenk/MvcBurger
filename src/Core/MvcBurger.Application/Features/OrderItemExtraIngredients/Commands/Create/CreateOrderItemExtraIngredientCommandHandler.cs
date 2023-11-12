using AutoMapper;
using MediatR;
using MvcBurger.Application.Repositories.ExtraIngredientMenuOrder;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateOrderItemExtraIngredientCommandHandler : IRequestHandler<CreateOrderItemExtraIngredientRequest, CreateOrderItemExtraIngredientResponse>
    {
        private readonly IOrderItemExtraIngredientRepository _menuOrderExtraIngredientRepository;
        private readonly IMapper _mapper;

        public CreateOrderItemExtraIngredientCommandHandler(IOrderItemExtraIngredientRepository menuOrderExtraIngredientRepository, IMapper mapper)
        {
            _menuOrderExtraIngredientRepository = menuOrderExtraIngredientRepository;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateOrderItemExtraIngredientResponse> Handle(CreateOrderItemExtraIngredientRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var menuOrderExtraIngredient = _mapper.Map<OrderItemExtraIngredient>(request);


            await _menuOrderExtraIngredientRepository.AddAsync(menuOrderExtraIngredient);


            CreateOrderItemExtraIngredientResponse createdMenuOrderExtraIngredientResponse = _mapper.Map<CreateOrderItemExtraIngredientResponse>(menuOrderExtraIngredient);
            return createdMenuOrderExtraIngredientResponse;


        }
    }



}

