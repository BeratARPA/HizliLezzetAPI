using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Order.GetAll
{
    public class GetAllOrdersQuery : IRequest<ServiceResponse<List<OrderViewDto>>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ServiceResponse<List<OrderViewDto>>>
        {
            private readonly IOrderRepository orderRepository;
            private readonly IMapper mapper;

            public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                this.orderRepository = orderRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<OrderViewDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await orderRepository.GetAllAsync();

                var viewModel = mapper.Map<List<OrderViewDto>>(orders);

                return new ServiceResponse<List<OrderViewDto>>(viewModel);
            }
        }
    }
}
