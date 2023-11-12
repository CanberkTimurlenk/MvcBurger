using AutoMapper;
using MediatR;


namespace MvcBurger.Application.Features.Orders.Queries.GetCartByUserId
{
    /*
    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdRequest, GetCartByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IARepository _aRepository;

        public GetByIdAQueryHandler(IMapper mapper, IARepository aRepository)
        {
            _mapper = mapper;
            _aRepository = aRepository;
        }

        public async Task<GetByIdAResponse> Handle(GetByIdARequest request, CancellationToken cancellationToken)
        {
            var a = await _aRepository.Get(d => d.Id == request.Id);

            GetByIdAResponse response = _mapper.Map<GetByIdAResponse>(a);

            return response;
        }
    */
}

