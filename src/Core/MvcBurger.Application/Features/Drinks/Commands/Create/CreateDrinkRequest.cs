using MediatR;

namespace MvcBurger.Application.Features.Commands.Drinks.Create
{
    public class CreateDrinkRequest : IRequest<CreateDrinkResponse>
    {
        public string Name { get; set; }
    }



}

