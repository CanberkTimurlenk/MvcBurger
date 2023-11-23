using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;

namespace MvcBurger.Application.Features.Menus.Commands.Update
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuRequest, UpdateMenuResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateMenuCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UpdateMenuResponse> Handle(UpdateMenuRequest request, CancellationToken cancellationToken)
        {
            var menu = await _repositoryManager.Menu.FindAsync(request.Id);

            _mapper.Map(request, menu);
            await _repositoryManager.SaveAsync();

            return new UpdateMenuResponse { };



        }
    }

}




