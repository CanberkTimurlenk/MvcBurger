using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcBurger.Application.Features.Commands.Drinks.Create;
using MvcBurger.Application.Features.Commands.Menus.Create;
using MvcBurger.Application.Features.ExtraIngredients.Commands.Update;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Commands.Delete;
using MvcBurger.Application.Features.Menus.Commands.Update;
using MvcBurger.Application.Features.Menus.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem;
using MvcBurger.Application.Features.Queries.ExtraIngredients.GetById;
using MvcBurger.Web.Areas.Admin.Models;
using MvcBurger.Web.Models.VMs;

namespace MvcBurger.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Menus()
        {
            var response = await _mediator.Send(new GetAllMenusRequest());

            return View(new GetMenuListVM { MenuList = response.List });
        }
        [Route("/menu/add")]
        public IActionResult AddMenu()
        {
            TempData["actionName"] = "AddMenu";
            TempData["button"] = "Add Menu";
            return PartialView("CreateUpdateMenu", new MenuVM());
        }
        [HttpPost]
        [Route("/menu/add")]
        public async Task<IActionResult> AddMenu(MenuVM newMenu)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateMenuRequest()
                {
                    Name = newMenu.Name,
                    Description = newMenu.Description,
                    Price = newMenu.Price,
                    ImageUrl = newMenu.ImageUrl
                });
                return RedirectToAction(nameof(Menus));
            }
            TempData["actionName"] = "AddMenu";
            TempData["button"] = "Add Menu";
            return PartialView("CreateUpdateMenu", new MenuVM());
        }
        [Route("/menu/update-{Id}")]
        public async Task<IActionResult> UpdateMenu(Guid Id)
        {
            TempData["actionName"] = "UpdateMenu";
            TempData["button"] = "Update Menu";
            var menu = await _mediator.Send(new GetByIdMenuRequest() { Id = Id });
            MenuVM vm = new MenuVM()
            {
                Name = menu.Name,
                Description = menu.Description,
                Price = menu.Price,
                ImageUrl = menu.ImageUrl
            };
            return PartialView("CreateUpdateMenu", vm);
        }
        [HttpPost]
        [Route("/menu/update-{Id}")]
        public async Task<IActionResult> UpdateMenu(MenuVM updatedMenu)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateMenuRequest()
                {
                    Name = updatedMenu.Name,
                    Description = updatedMenu.Description,
                    Price = updatedMenu.Price,
                    ImageUrl = updatedMenu.ImageUrl,
                    Id = updatedMenu.Id
                });
                return RedirectToAction(nameof(Menus));
            }
            TempData["actionName"] = "UpdateMenu";
            TempData["button"] = "Update Menu";
            return PartialView("CreateUpdateMenu", updatedMenu);
        }
        public async Task<IActionResult> DeleteMenu(Guid Id)
        {
            await _mediator.Send(new DeleteMenuRequest() { MenuId = Id });
            return RedirectToAction(nameof(Menus));
        }

        public async Task<IActionResult> Extras()
        {
            var response = await _mediator.Send(new GetAllExtraIngredientsRequest());
            return View(new GetExtraIngredientsListVM() { ExstraList = response.List });
        }
        [Route("/extra/add")]
        public IActionResult AddExtra()
        {
            TempData["actionName"] = "AddExtra";
            TempData["button"] = "Add Ingredient";
            return PartialView("CreateUpdateIngredient", new ExtraIngredientVM());
        }
        [HttpPost]
        [Route("/extra/add")]
        public async Task<IActionResult> AddExtra(ExtraIngredientVM newExtra)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateExtraIngredientRequest()
                {
                    Name = newExtra.Name,
                    Price = newExtra.Price
                });
                return RedirectToAction(nameof(Extras));
            }
            TempData["actionName"] = "AddExtra";
            TempData["button"] = "Add Ingredient";
            return PartialView("CreateUpdateIngredient", newExtra);
        }
        [Route("/extra/update-{Id}")]
        public async Task<IActionResult> UpdateExtra(Guid Id)
        {
            TempData["actionName"] = "UpdateExtra";
            TempData["button"] = "Update Ingredient";
            var response = await _mediator.Send(new GetByIdExtraIngredientRequest() { Id = Id });
            ExtraIngredientVM extra = new ExtraIngredientVM()
            {
                Name = response.Name,
                Price = response.Price
            };

            return PartialView("CreateUpdateIngredient", extra);
        }
        [HttpPost]
        [Route("/extra/update-{Id}")]
        public async Task<IActionResult> UpdateExtra(Guid Id, ExtraIngredientVM extra)
        {
            TempData["actionName"] = "UpdateExtra";
            TempData["button"] = "Update Ingredient";
            if (!ModelState.IsValid)
                return PartialView("CreateUpdateIngredient", extra);

            await _mediator.Send(new UpdateExtraIngredientRequest()
            {
                Id = Id,
                Name = extra.Name,
                Price = extra.Price,
            });
            return RedirectToAction(nameof(Extras));
        }

        public async Task<IActionResult> DeleteExtra(Guid Id)
        {
            await _mediator.Send(new DeleteExtraIngredientRequest() { ExtraIngredientId = Id });
            return RedirectToAction(nameof(Extras));
        }
    }
}
