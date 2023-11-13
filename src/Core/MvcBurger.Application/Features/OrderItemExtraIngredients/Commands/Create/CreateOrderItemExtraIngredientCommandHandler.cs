using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.OrderItemExtraIngredients;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateOrderItemExtraIngredientCommandHandler : IRequestHandler<CreateOrderItemExtraIngredientRequest, CreateOrderItemExtraIngredientResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateOrderItemExtraIngredientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<CreateOrderItemExtraIngredientResponse> Handle(CreateOrderItemExtraIngredientRequest request, CancellationToken cancellationToken)
        {

            var orderItemExtraIngredient = _mapper.Map<OrderItemExtraIngredient>(request);


            await _repositoryManager.OrderItemExtraIngredient.AddAsync(orderItemExtraIngredient);


            CreateOrderItemExtraIngredientResponse createdOrderItemExtraIngredientResponse = _mapper.Map<CreateOrderItemExtraIngredientResponse>(orderItemExtraIngredient);
            return createdOrderItemExtraIngredientResponse;


        }
    }



}

