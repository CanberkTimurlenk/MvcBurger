
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using MvcBurger.Application.Exceptions.BadRequestException;
using MvcBurger.Application.Features.Users.Commands.Create;
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
        [Route("u/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("u/Login")]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {

            if (ModelState.IsValid)
            {

                LoginAppUserRequest request = new LoginAppUserRequest()
                {
                    Password = loginVM.Password,
                    Email = loginVM.Email
                };
                LoginAppUserResponse loginResponse;

                loginResponse = await _mediator.Send(request);

                if (loginResponse.UserId is null)
                    return View();

                HttpContext.Session.SetString("userId", loginResponse.UserId);
                HttpContext.Session.SetString("roles", string.Join(",", loginResponse.Roles));

                    if (loginResponse.Roles.Contains("Admin"))
                        return RedirectToAction("Menus", "Home", new { area = "Admin" });

                    return RedirectToAction("Index", "Home");                
            }

            return View(loginVM);
        }
        [Route("u/Register")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("u/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVM userVM)
        {
            if (ModelState.IsValid)
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
                    ViewBag.errorMessage = userVM.Email + " is already in use!";
                    return View(userVM);
                }
            }
            return View(userVM);
        }
        public async Task<IActionResult> Logout()
        {
            LogoutAppUserRequest request = new LogoutAppUserRequest();
            await _mediator.Send(request);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
