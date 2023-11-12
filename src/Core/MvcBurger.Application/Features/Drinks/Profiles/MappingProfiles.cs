using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;
using MvcBurger.Application.Features.Queries.Drinks.GetById;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Drinks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Drink, CreateDrinkRequest>().ReverseMap();
            CreateMap<Drink, CreateDrinkResponse>().ReverseMap();

            CreateMap<Drink, GetByIdDrinkRequest>().ReverseMap();
            CreateMap<Drink, GetByIdDrinkResponse>().ReverseMap();


            CreateMap<Drink, GetAllDrinksResponseListItem>().ReverseMap();

        }
    }
}
