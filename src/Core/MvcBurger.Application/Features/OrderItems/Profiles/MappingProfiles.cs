using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Application.Features.OrderItems.Queries.GetById;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.OrderItems.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderItem, GetByIdOrderItemRequest>().ReverseMap();
            CreateMap<OrderItem, GetByIdOrderItemResponse>().ReverseMap();

        }
    }
}
