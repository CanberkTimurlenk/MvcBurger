using AutoMapper;
using MvcBurger.Application.Features.Commands.Menus.Create;
using MvcBurger.Application.Features.Menus.Commands.Update;
using MvcBurger.Application.Features.Menus.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Menus.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Menu, CreateMenuRequest>().ReverseMap();
            CreateMap<Menu, CreateMenuResponse>().ReverseMap();

            CreateMap<Menu, GetAllMenuResponseListItem>().ReverseMap();

            CreateMap<Menu, GetByIdMenuResponse>().ReverseMap();
            CreateMap<Menu, GetByIdMenuRequest>().ReverseMap();

            CreateMap<Menu, UpdateMenuRequest>().ReverseMap();
            CreateMap<Menu, UpdateMenuResponse>().ReverseMap();

        }
    }
}
