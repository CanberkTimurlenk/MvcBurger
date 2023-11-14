using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MvcBurger.Application.Features.ExtraIngredients.Queries.GetAll;
using MvcBurger.Application.Features.Menus.Queries.GetById;
using MvcBurger.Application.Features.Orders.Commands.AddToCart;
using MvcBurger.Application.Features.Orders.Queries.GetCartByUserId;
using MvcBurger.Application.Features.Queries.Drinks.GetAll;
using MvcBurger.Web.Models.VMs;
using Newtonsoft.Json;
using System.Drawing.Printing;

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
            return View(selected);
        }
        [HttpPost]
        public async Task<IActionResult> OrderDetail(SelectedMenuVM selected)
        {
            OrderItemRequest orderItemRequest = new OrderItemRequest()
            {
                DrinkId = selected.SelectedDrinkId,
                MenuId = selected.MenuId,                
                // menuId gelmiyorrr
                //Amount = selected.Amount,
                //Size = selected.Size
            };

            IEnumerable<OrderItemRequest> orderItems = new List<OrderItemRequest>() { orderItemRequest }.AsEnumerable();

            AddToCartRequest addToCartRequest = new AddToCartRequest() { AppUserId = HttpContext.Session.GetString("userId"), OrderItemRequest = orderItems };

            var response = await _mediator.Send(addToCartRequest);

            GetUserCartVM userCartVM = new GetUserCartVM() { Cart = response.Cart };

            return RedirectToAction("Cart",userCartVM);
        }

        //public IActionResult Cart()
        //{

        //}
    }
}
