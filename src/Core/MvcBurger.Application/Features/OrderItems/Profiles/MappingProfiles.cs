using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.MenuOrders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderItemExtraIngredient, CreateMenuOrderExtraIngredientResponse>().ReverseMap();
            CreateMap<OrderItemExtraIngredient, CreateMenuOrderExtraIngredientResponse>().ReverseMap();

        }
    }
}
z