using MediatR;

namespace MvcBurger.Application.Features.Menus.Queries.GetById
{
    public class GetByIdMenuRequest : IRequest<GetByIdMenuResponse>
    {
        public Guid Id { get; set; }

    }
}
