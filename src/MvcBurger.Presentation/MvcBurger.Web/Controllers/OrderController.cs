using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Application.Features.OrderItems.Queries.GetById;
using MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart;
using MvcBurger.Application.Features.Orders.Commands.Cart.Checkout;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem;
using MvcBurger.Application.Features.Orders.Queries.GetCartByUserId;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;
using MvcBurger.Web.Models.VMs;

namespace MvcBurger.Web.Controllers
{
    //_Otder layout ile, OrderPartial layout birlesecek
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("od/menu-{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateOrder(Guid Id) // Order Creation Page
        {
            TempData["submitAction"] = nameof(CreateOrder);
            var menuResponse = await _mediator.Send(new GetByIdMenuRequest() { Id = Id });

            var fields = (await GetFields());

            SelectedMenuVM selected = new SelectedMenuVM()
            {
                MenuId = menuResponse.Id,
                Description = menuResponse.Description,
                ImageUrl = menuResponse.ImageUrl,
                Name = menuResponse.Name,
                Price = menuResponse.Price
            };

            selected.AllExtraIngredients = fields.ingredients.List.ToList();
            selected.AllDrinks = fields.drinks.List.ToList();

            selected.Extras = selected.AllExtraIngredients.Select(ei => new SelectedExtraItem
            {
                ExtraName = ei.Name,
                SelectedIngredientId = ei.Id,
            }).ToList();

            string js = System.Text.Json.JsonSerializer.Serialize(selected);

            TempData["selectedMenu"] = js;

            return PartialView("OrderPartial", selected);
        }

        [Route("od/menu-{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(SelectedMenuVM selected)
        {
            var selectedTemp = System.Text.Json.JsonSerializer.Deserialize<SelectedMenuVM>(TempData["selectedMenu"] as string);

            var selectedExtras = selected.Extras.Where(e => e.Checked).Select(e => e.SelectedIngredientId);

            OrderItemRequest orderItemRequest = new OrderItemRequest()
            {
                Size = selected.SelectedSize,
                Amount = selected.Amount,
                DrinkId = selected.SelectedDrinkId,
                MenuId = selectedTemp.MenuId,
                ExtraIngredientId = selectedExtras
            };

            IEnumerable<OrderItemRequest> orderItems = new List<OrderItemRequest>() { orderItemRequest }.AsEnumerable();

            AddToCartRequest addToCartRequest = new AddToCartRequest()
            {
                AppUserId = HttpContext.User.Claims.First().Value,
                OrderItemRequest = orderItems
            };

            var response = await _mediator.Send(addToCartRequest);

            GetUserCartVM userCartVM = new GetUserCartVM() { Cart = response.Cart };

            return RedirectToAction(nameof(Cart), userCartVM);
        }

        public async Task<IActionResult> Cart(GetUserCartVM userCartVM)
        {
            GetCartByUserIdRequest request = new GetCartByUserIdRequest() { AppUserId = HttpContext.User.Claims.First().Value };

            if (userCartVM.Cart is null)
            {
                userCartVM.Cart = (await _mediator.Send(request)).Cart;
                return View(userCartVM);
            }

            return View();
        }

        public async Task<IActionResult> Checkout()
        {
            await _mediator.Send(new CheckoutRequest() { AppUserId = HttpContext.User.Claims.First().Value });

            return View(nameof(Cart));
        }

        public async Task<IActionResult> RemoveCartItem(Guid Id)
        {
            await _mediator.Send(new DeleteCartItemRequest { AppUserId = HttpContext.User.Claims.First().Value, OrderItemId = Id });
            return RedirectToAction(nameof(Cart));
        }
        [Route("c/order-{id}")]
        public async Task<IActionResult> UpdateCartItem(Guid Id)
        {
            TempData["submitAction"] = nameof(UpdateCartItem);
            var fields = await GetFields();

            GetByIdOrderItemRequest orderItem = new GetByIdOrderItemRequest() { Id = Id };

            var response = await _mediator.Send(orderItem);
            var menuResponse = await _mediator.Send(new GetByIdMenuRequest() { Id = response.MenuId });

            SelectedMenuVM updateMenuVm = new SelectedMenuVM()
            {
                Description = menuResponse.Description,
                ImageUrl = menuResponse.ImageUrl,
                Name = menuResponse.Name,
                Price = menuResponse.Price,
                Amount = response.Amount,
                SelectedDrinkId = response.DrinkId,
                SelectedExtraIngredients = response.OrderItemExtraIngredient,
                MenuId = response.MenuId,
                SelectedSize = response.Size,
                AllDrinks = fields.drinks.List.ToList(),
                AllExtraIngredients = fields.ingredients.List.ToList()

            };

            updateMenuVm.Extras = updateMenuVm.AllExtraIngredients.Select(ei => new SelectedExtraItem
            {
                ExtraName = ei.Name,
                SelectedIngredientId = ei.Id
            }).ToList();

            updateMenuVm.Extras.ForEach(ei =>
            {
                if (updateMenuVm.SelectedExtraIngredients.Any(se => se.ExtraIngredientId == ei.SelectedIngredientId))
                    ei.Checked = true;
            });

            TempData["menuId"] = updateMenuVm.MenuId;

            return PartialView("OrderPartial", updateMenuVm);
        }

        [Route("c/order-{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCartItem(Guid Id, SelectedMenuVM updateMenuVm)
        {


            var menuId = (Guid)TempData["menuId"];


            OrderItemRequest orderitem = new OrderItemRequest
            {
                Amount = updateMenuVm.Amount,
                DrinkId = updateMenuVm.SelectedDrinkId,
                ExtraIngredientId = updateMenuVm.Extras.Where(e => e.Checked).Select(e => e.SelectedIngredientId).ToList(),
                MenuId = menuId,
                Size = updateMenuVm.SelectedSize
            };


            UpdateCartItemRequest request = new UpdateCartItemRequest() { OrderItemId = Id, AppUserId = HttpContext.User.Claims.First().Value, OrderItemRequest = orderitem };

            await _mediator.Send(request);
            return RedirectToAction(nameof(Cart));
        }


        private async Task<(GetAllExtraIngredientsResponse ingredients, GetAllDrinksResponse drinks)>
            GetFields()
        {
            var ingredientsResponse = await _mediator.Send(new GetAllExtraIngredientsRequest());

            var drinksResponse = await _mediator.Send(new GetAllDrinksRequest());

            return (ingredientsResponse, drinksResponse);
        }

    }
}

