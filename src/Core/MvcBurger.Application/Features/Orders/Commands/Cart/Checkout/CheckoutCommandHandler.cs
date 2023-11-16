using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Domain.Enums;

namespace MvcBurger.Application.Features.Orders.Commands.Cart.Checkout
{
    public class CheckoutCommandHandler : IRequestHandler<CheckoutRequest, CheckoutResponse>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CheckoutCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CheckoutResponse> Handle(CheckoutRequest request, CancellationToken cancellationToken)
        {
            var cartContent = await _repositoryManager.Order.GetAllAsync(o => o.AppUserId.Equals(request.AppUserId) && o.OrderStatus == OrderStatus.Cart);

            if (cartContent.Count() > 0)
            {
                cartContent.ToList().ForEach(cartContent => cartContent.OrderStatus = OrderStatus.PaymentReceived);

                await _repositoryManager.SaveAsync();
            }


            return new CheckoutResponse();
        }
    }
}