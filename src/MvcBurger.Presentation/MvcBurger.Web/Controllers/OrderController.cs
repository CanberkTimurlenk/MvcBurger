using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcBurger.Application.Features.Orders.Queries.GetCartByUserId;
using MvcBurger.Web.Models.VMs;
using System.Drawing.Printing;

namespace MvcBurger.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> UserOrder(string userId)
        {

            GetCartByUserIdRequest request = new GetCartByUserIdRequest() { AppUserId = userId };
            
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
    }
}
