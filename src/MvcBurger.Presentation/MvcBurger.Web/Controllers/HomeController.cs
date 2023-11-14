using MediatR;
using Microsoft.AspNetCore.Mvc;
using MvcBurger.Application.Features.Menus.Queries.GetAll;
using MvcBurger.Persistance.Contexts;
using MvcBurger.Web.Models;
using MvcBurger.Web.Models.VMs;
using Newtonsoft.Json;
using System.Diagnostics;

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

            var getAllMenusRequest = new GetAllMenusRequest() { };

            var allMenus = await _mediator.Send(getAllMenusRequest);

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