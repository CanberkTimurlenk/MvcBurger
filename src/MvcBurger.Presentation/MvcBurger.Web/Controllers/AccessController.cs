using ConsoleApplication.NewFolder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using MvcBurger.Application.Exceptions.BadRequestException;
using MvcBurger.Application.Features.Users.Queries.Login;
using MvcBurger.Application.Features.Users.Queries.Logout;
using MvcBurger.Domain.Entities;
using MvcBurger.Web.Models.VMs;

namespace MvcBurger.Web.Controllers
{
    public class AccessController : Controller
    {
        private readonly IMediator _mediator;

        public AccessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVM, string ReturnUrl)
        {
            LoginAppUserRequest request = new LoginAppUserRequest()
            {
                Password = loginVM.Password,
                Email = loginVM.Email
            };
            LoginAppUserResponse loginResponse;

            try
            {
                loginResponse = await _mediator.Send(request);

            }
            catch (Exception)
            {
                return View();
            }

            if (loginResponse.UserId is not null)
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                return View(loginVM);
        }
        public IActionResult Register()
        {
            // register view

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVM userVM)
        {
            var request = new CreateAppUserRequest()
            {
                Address = userVM.Address,
                Password = userVM.Password,
                Email = userVM.Email,
                Firstname = userVM.Firstname,
                Lastname = userVM.Lastname
            };
            CreateAppUserResponse response;
            try
            {
                response = await _mediator.Send(request);
            }
            catch (Exception)
            {
                return View();
            }
            if (response.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // kayıt başarısız
                // response.Message
                // burda mesaj mevcut geri bildirim verebilirsin
                return View(userVM);
            }
        }
        public async Task<IActionResult> Logout()
        {
            LogoutAppUserRequest request = new LogoutAppUserRequest();
            await _mediator.Send(request);
            return RedirectToAction("Index", "Home");
        }
    }
}
