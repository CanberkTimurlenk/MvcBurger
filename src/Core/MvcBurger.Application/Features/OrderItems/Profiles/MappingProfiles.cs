using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.OrderItems.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderItemExtraIngredient, CreateOrderItemExtraIngredientResponse>().ReverseMap();
            CreateMap<OrderItemExtraIngredient, CreateOrderItemExtraIngredientResponse>().ReverseMap();

        }
    }
}
