using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Order.GetById
{
    public class GetOrderByIdQuery : IRequest<ServiceResponse<OrderViewDto>>
    {
        public Guid Id { get; set; }

        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ServiceResponse<OrderViewDto>>
        {
            private readonly IOrderRepository orderRepository;
            private readonly IMapper mapper;

            public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                this.orderRepository = orderRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<OrderViewDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                var order = await orderRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<OrderViewDto>(order);

                return new ServiceResponse<OrderViewDto>(viewModel);
            }
        }
    }
}
