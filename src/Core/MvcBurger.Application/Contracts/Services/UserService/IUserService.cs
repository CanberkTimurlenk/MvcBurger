using MvcBurger.Application.DTOs.User.Create;
using MvcBurger.Domain.Entities;

namespace MvcBurger.Application.Contracts.Services.UserService
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
        Task AssignRoleToUserAsnyc(string userId, string[] roles);
        Task<AppUser> FindByEmailAsync(string email);
    }
}
