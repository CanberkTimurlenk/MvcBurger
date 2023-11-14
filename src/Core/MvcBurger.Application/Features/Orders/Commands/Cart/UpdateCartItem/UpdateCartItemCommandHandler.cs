﻿using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Exceptions.NotFoundException;
using MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart;
using MvcBurger.Domain.Entities;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemRequest, UpdateCartItemResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateCartItemCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            // business rules if exists

        }

        public async Task<UpdateCartItemResponse> Handle(UpdateCartItemRequest request, CancellationToken cancellationToken)
        {

            var cartItem = await _repositoryManager.OrderItem.Get(o => o.Id.Equals(request.OrderItemId));

            if (cartItem is null)
                throw new CartItemNotFoundException(request.AppUserId, request.OrderItemId);

            _mapper.Map(cartItem, request.OrderItemRequest);

            var extra = request.OrderItemRequest.ExtraIngredientId.Select(ei => new OrderItemExtraIngredient
            {
                ExtraIngredientId = ei,
                OrderItemId = cartItem.Id
            }).ToList();

            cartItem.OrderItemExtraIngredient = extra;


            _repositoryManager.OrderItem.Update(cartItem);
            await _repositoryManager.SaveAsync();

            var cart = await _repositoryManager.Order.GetCartByUserId(request.AppUserId);
            return new UpdateCartItemResponse { Cart = cart };

        }
    }

}




