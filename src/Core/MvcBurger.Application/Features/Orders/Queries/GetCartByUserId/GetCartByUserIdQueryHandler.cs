using AutoMapper;
using MediatR;
using MvcBurger.Application.Contracts.Repositories.RepositoryManager;
using MvcBurger.Application.DTOs.Cart;
using MvcBurger.Application.Helpers;

namespace MvcBurger.Application.Features.Orders.Queries.GetCartByUserId
{

    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdRequest, GetCartByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCartByUserIdQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<GetCartByUserIdResponse> Handle(GetCartByUserIdRequest request, CancellationToken cancellationToken)
        {
            var cart = await _repositoryManager.Order.GetCartByUserId(request.AppUserId);

            if (cart is not null)
                cart.TotalPrice = CartHelper.GetTotalCartPrice(cart);

            return new GetCartByUserIdResponse { Cart = cart };
        }



    }
}

