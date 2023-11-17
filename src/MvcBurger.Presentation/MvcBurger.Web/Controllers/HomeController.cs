using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MvcBurger.Application.Features.Menus.Queries.GetAll;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Web.Models;
using MvcBurger.Web.Models.VMs;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace MvcBurger.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var roles = HttpContext.Session.GetString("roles");
            if (roles is not null && roles.Contains("Admin"))
                return RedirectToAction("Menus", "Home", new { area = "Admin" });

            var allMenus = await _mediator.Send(new GetAllMenusRequest());

            return View(new GetMenuListVM { MenuList = allMenus.List });
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Error(string errors = "")
        {
            var err = JsonConvert.DeserializeObject<List<string>>(HttpContext.Session.GetString("Errors"));

            var errorMessages = string.Join(Environment.NewLine, err);

            return Content(errorMessages);
        }
    }
}