using AutoMapper;
using MediatR;
using MvcBurger.Application.Features.Commands.Menus.Create;
using MvcBurger.Application.Repositories;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Features.Menus.Create
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuRequest, CreateMenuResponse>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            // business rules if exists

        }


        public async Task<CreateMenuResponse> Handle(CreateMenuRequest request, CancellationToken cancellationToken)
        {

            // service logic
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........


            var menu = _mapper.Map<Menu>(request);
            menu.Id = Guid.NewGuid();

            await _menuRepository.AddAsync(menu);


            CreateMenuResponse createMenuResponse = _mapper.Map<CreateMenuResponse>(menu);
            return createMenuResponse;


        }
    }



}

