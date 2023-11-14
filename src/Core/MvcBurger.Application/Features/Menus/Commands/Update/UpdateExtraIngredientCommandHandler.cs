﻿using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.Exceptions.NotFoundException;
using MvcBurger.Domain.Entities;

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
            // business rules if exists

        }

        public async Task<UpdateMenuResponse> Handle(UpdateMenuRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<UpdateMenuRequest, ExtraIngredient>(request);

            var menu = await _repositoryManager.Menu.FindAsync(request.MenuId);

            _mapper.Map(request, menu);
            await _repositoryManager.SaveAsync();

            return new UpdateMenuResponse { };



        }
    }

}



