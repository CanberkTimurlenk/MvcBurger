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

            //selected.Sizes = new SelectList(Enum.GetValues(typeof(Size)));
            selected.ExtraIngredients = ingredientsResponse.List.ToList();
            selected.Drinks = drinksResponse.List.ToList();
            //tempdata ile tasimak icin boyutu mu buyuk acaba????
            //TempData["selectedvm"]= selected;

            selected.ekstralar = selected.ExtraIngredients.Select(ei => new selectListBenzeri
            {
                EkstraMalzemeAdi = ei.Name,
                SelectedIngredientId = ei.Id,
            }).ToList();

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



            var selectedExtras = selected.ekstralar.Where(e => e.IstiyorMusun).Select(e => e.SelectedIngredientId);



            OrderItemRequest orderItemRequest = new OrderItemRequest()
            {
                Size = selected.SelectedSize,
                Amount = selected.Amount,
                DrinkId = selected.SelectedDrinkId,
                MenuId = selectedTemp.MenuId,
                ExtraIngredientId = selectedExtras
            };
            // menuId gelmiyorrr

            //Amount = selected.Amount,
            //Size = selected.Size

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


    }


}

