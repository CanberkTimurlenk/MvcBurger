using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Services.UserService;

namespace MvcBurger.Application.Features.Users.Commands.Create
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserRequest, CreateAppUserResponse>
    {
        private readonly IUserService _userService;

        public CreateAppUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
        }

        public async Task<CreateAppUserResponse> Handle(CreateAppUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Address = request.Address,
                Password = request.Password
            });

            return new CreateAppUserResponse
            {
                Succeeded = result.Succeeded,
                Message = result.Message
            };
        }
    }
}

