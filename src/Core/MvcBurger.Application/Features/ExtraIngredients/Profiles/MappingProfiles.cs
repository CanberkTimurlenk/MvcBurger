using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Application.Features.Queries.ExtraIngredients.GetById;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.ExtraIngredients.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ExtraIngredient, CreateExtraIngredientRequest>().ReverseMap();
            CreateMap<ExtraIngredient, CreateExtraIngredientResponse>().ReverseMap();

            CreateMap<ExtraIngredient, GetAllExtraIngredientResponseListItem>().ReverseMap();

            CreateMap<ExtraIngredient, GetByIdExtraIngredientRequest>().ReverseMap();
            CreateMap<ExtraIngredient, GetByIdExtraIngredientResponse>().ReverseMap();


        }
    }
}
