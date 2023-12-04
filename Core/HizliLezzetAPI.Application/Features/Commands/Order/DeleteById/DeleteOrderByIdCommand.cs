using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Order.DeleteById
{
    public class DeleteOrderByIdCommand : IRequest<ServiceResponse<OrderViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, ServiceResponse<OrderViewDto>>
        {
            private readonly IOrderRepository orderRepository;
            private readonly IMapper mapper;

            public DeleteOrderByIdCommandHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                this.orderRepository = orderRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<OrderViewDto>> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
            {
                var order = await orderRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<OrderViewDto>(order);

                return new ServiceResponse<OrderViewDto>(viewModel);
            }
        }
    }
}
