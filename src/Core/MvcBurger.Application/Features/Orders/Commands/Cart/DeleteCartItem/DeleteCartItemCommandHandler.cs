﻿using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Exceptions.NotFoundException;
using MvcBurger.Application.Helpers;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.DeleteCartItem
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemRequest, DeleteCartItemResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DeleteCartItemCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
         

        }

        public async Task<DeleteCartItemResponse> Handle(DeleteCartItemRequest request, CancellationToken cancellationToken)
        {

            var cartItemToDelete = await _repositoryManager.OrderItem.FindAsync(request.OrderItemId);

            if (cartItemToDelete == null)
                throw new CartItemNotFoundException(request.AppUserId, request.OrderItemId);

            _repositoryManager.OrderItem.Remove(cartItemToDelete);

            var extraIngredientsToDelete = await _repositoryManager.OrderItemExtraIngredient.GetAllAsync(oi => oi.OrderItemId == request.OrderItemId);

            _repositoryManager.OrderItemExtraIngredient.RemoveRange(extraIngredientsToDelete);


            await _repositoryManager.SaveAsync();

            var cart = await _repositoryManager.Order.GetCartByUserId(request.AppUserId);

            if (cart is not null)
                cart.TotalPrice = CartHelper.GetTotalCartPrice(cart);

            return new DeleteCartItemResponse { Cart = cart };

        }
    }

}




