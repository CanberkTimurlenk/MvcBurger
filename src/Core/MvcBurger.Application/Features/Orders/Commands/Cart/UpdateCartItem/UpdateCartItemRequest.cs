﻿using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem
{
    public class UpdateCartItemRequest : IRequest<UpdateCartItemResponse>
    {
        public string AppUserId { get; set; }
        public Guid OrderItemId { get; set; }
        public OrderItemRequest OrderItemRequest { get; set; }

    }


}

