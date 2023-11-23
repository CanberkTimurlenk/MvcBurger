using AutoMapper;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Orders.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderItemRequest, OrderItem>().ReverseMap();
            
        }

    }
}
