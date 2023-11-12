﻿using AutoMapper;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.MenuOrderExtraIngredients.Commands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MenuOrderExtraIngredient, CreateOrderItemExtraIngredientRequest>().ReverseMap();
            CreateMap<MenuOrderExtraIngredient, CreateOrderItemExtraIngredientResponse>().ReverseMap();
        }
    }
}
