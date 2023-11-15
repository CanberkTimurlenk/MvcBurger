using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Application.Features.OrderItems.Queries.GetById;
using MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Application.Features.Orders.Commands.Cart.UpdateCartItem;
using MvcBurger.Application.Features.Orders.Queries.GetCartByUserId;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;

using MvcBurger.Web.Models.VMs;
using Newtonsoft.Json;
using System.Text.Json;

namespace MvcBurger.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;


        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> UserOrder()
        {

            GetCartByUserIdRequest request = new GetCartByUserIdRequest() { AppUserId = HttpContext.Session.GetString("userId") };

            var response = await _mediator.Send(request);
            GetUserCartVM vm = new GetUserCartVM()
            {
                Cart = response.Cart,
            };

            return View(vm);
        }

        [Route("od/product-{id}")]
        [HttpGet]
        public async Task<IActionResult> OrderDetail(Guid Id)
        {
            TempData["submitAction"] = "OrderDetail";
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

            //selected.Sizes = new SelectList(Enum.GetValues(typeof(Size)));
            selected.AllExtraIngredients = fields.ingredients.List.ToList();
            selected.AllDrinks = fields.drinks.List.ToList();
            //tempdata ile tasimak icin boyutu mu buyuk acaba????
            //TempData["selectedvm"]= selected;

            selected.Extras = selected.AllExtraIngredients.Select(ei => new SelectedExtraItem
            {
                ExtraName = ei.Name,
                SelectedIngredientId = ei.Id,
            }).ToList();

            string js = System.Text.Json.JsonSerializer.Serialize(selected);

            TempData["selectedMenu"] = js;

            return PartialView("OrderPartial", selected);
        }
        [Route("od/product-{id}")]
        [HttpPost]
        public async Task<IActionResult> OrderDetail(SelectedMenuVM selected)
        {

            //duzenleme yapilmasi gerek (belki vm yerine tempdata kullanilabilir)
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
                //AppUserId = HttpContext.Session.GetString("userId"),
                AppUserId = HttpContext.User.Claims.First().Value,


                OrderItemRequest = orderItems

            };

            var response = await _mediator.Send(addToCartRequest);

            GetUserCartVM userCartVM = new GetUserCartVM() { Cart = response.Cart };

            return RedirectToAction("Cart", userCartVM);
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

        public async Task<IActionResult> Remove(Guid Id)
        {
            await _mediator.Send(new DeleteCartItemRequest { AppUserId = HttpContext.User.Claims.First().Value, OrderItemId = Id });
            return RedirectToAction("Cart");
        }
        //[Route("c/order-{id}")]
        public async Task<IActionResult> Update(Guid Id)
        {
            TempData["submitAction"] = "Update";
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


            //updateMenuVm.Extras
            updateMenuVm.Extras.ForEach(ei =>
            {
                if (updateMenuVm.SelectedExtraIngredients.Any(se => se.ExtraIngredientId == ei.SelectedIngredientId))
                    ei.Checked = true;
            });


            TempData["menuId"] = updateMenuVm.MenuId;



            // PartialView ı aç
            return PartialView("OrderPartial", updateMenuVm);
        }
        //[Route("c/order-{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(Guid Id, SelectedMenuVM updateMenuVm)
        {
            /*

            var tempMenuvm = JsonConvert.DeserializeObject<SelectedMenuVM>(TempData["updateMenu"] as string, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            
            if (tempMenuvm is not null)
            tempMenuvm.Extras = updateMenuVm.Extras;
            tempMenuvm.SelectedDrinkId = updateMenuVm.SelectedDrinkId;
            tempMenuvm.SelectedSize = updateMenuVm.SelectedSize;
            
            */

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
            return RedirectToAction("Cart");
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

