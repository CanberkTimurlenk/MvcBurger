using MediatR;

namespace MvcBurger.Application.Features.Commands.Menus.Create
{
    public class CreateMenuRequest : IRequest<CreateMenuResponse>
    {
        public string Name { get; set; }
    }



}

