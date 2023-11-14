using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Application.Features.Orders.Commands.Cart.AddToCart;
using MvcBurger.Application.Features.Orders.Commands.Cart.Common;
using MvcBurger.Application.Features.Orders.Queries.GetCartByUserId;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;
using MvcBurger.Web.Models.VMs;
using NuGet.Protocol;
using System.Drawing.Printing;
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
        public async Task<IActionResult> UserOrder(UserLoginVM loginVM)
        {

            GetCartByUserIdRequest request = new GetCartByUserIdRequest() { AppUserId = HttpContext.Session.GetString("userId") };

            var response = await _mediator.Send(request);
            GetUserCartVM vm = new GetUserCartVM()
            {
                Cart = response.Cart,
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult UserOrder()//, CreateOrderVM orderVm)
        {


            return View();
        }
        [Route("od/product-{id}")]
        [HttpGet]
        public async Task<IActionResult> OrderDetail(Guid Id)
        {
            GetByIdMenuRequest menuRequest = new GetByIdMenuRequest() { Id = Id };
            GetAllExtraIngredientsRequest ingredientsRequest = new GetAllExtraIngredientsRequest();
            GetAllDrinksRequest drinksRequest = new GetAllDrinksRequest();
            var menuResponse = await _mediator.Send(menuRequest);
            var ingredientsResponse = await _mediator.Send(ingredientsRequest);
            var drinksResponse = await _mediator.Send(drinksRequest);
            SelectedMenuVM selected = new SelectedMenuVM()
            {
                MenuId = menuResponse.Id,
                Description = menuResponse.Description,
                ImageUrl = menuResponse.ImageUrl,
                Name = menuResponse.Name,
                Price = menuResponse.Price
            };
            selected.ExtraIngredients = ingredientsResponse.List;
            selected.Drinks = drinksResponse.List;
            //tempdata ile tasimak icin boyutu mu buyuk acaba????
            //TempData["selectedvm"]= selected;

            string js = JsonSerializer.Serialize(selected);

            TempData["selectedMenu"] = js;

            return View(selected);
        }
        [Route("od/product-{id}")]
        [HttpPost]
        public async Task<IActionResult> OrderDetail(SelectedMenuVM selected)
        {
            //duzenleme yapilmasi gerek (belki vm yerine tempdata kullanilabilir)
            var selectedTemp = JsonSerializer.Deserialize<SelectedMenuVM>(TempData["selectedMenu"] as string);
            //
            OrderItemRequest orderItemRequest = new OrderItemRequest()
            {

                DrinkId = selected.SelectedDrinkId,
                MenuId = selectedTemp.MenuId,
                ExtraIngredientId = new List<Guid>
                {
                    new Guid("f0603b28-71fe-4d67-b2e0-ab25c16411f2"),
                    new Guid("f0603b28-71fe-4d67-b2e0-ab25c16411f2"),

                }
            };
            // menuId gelmiyorrr

            //Amount = selected.Amount,
            //Size = selected.Size

            IEnumerable<OrderItemRequest> orderItems = new List<OrderItemRequest>() { orderItemRequest }.AsEnumerable();

            AddToCartRequest addToCartRequest = new AddToCartRequest()
            {
                AppUserId = HttpContext.Session.GetString("userId"),
                OrderItemRequest = orderItems

            };

            var response = await _mediator.Send(addToCartRequest);

            GetUserCartVM userCartVM = new GetUserCartVM() { Cart = response.Cart };

            return RedirectToAction("Cart", userCartVM);
        }
    }

    //public IActionResult Cart()
    //{

    //}
}

