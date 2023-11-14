using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.OrderItemExtraIngredients.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderItemExtraIngredient, CreateOrderItemExtraIngredientRequest>().ReverseMap();
            CreateMap<OrderItemExtraIngredient, CreateOrderItemExtraIngredientResponse>().ReverseMap();
        }
    }
}
