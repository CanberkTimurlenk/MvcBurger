using MediatR;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Menus.Commands.Update
{
    public class UpdateMenuRequest : IRequest<UpdateMenuResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

    }


}

