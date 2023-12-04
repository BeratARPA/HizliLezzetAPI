using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Order.Create
{
    public class CreateOrderCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid TicketId { get; set; }
        public Guid SpecialProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public string CreatedUserName { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServiceResponse<Guid>>
        {
            private readonly IOrderRepository orderRepository;
            private readonly IMapper mapper;

            public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                this.orderRepository = orderRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var order = mapper.Map<Domain.Entities.Order>(request);
                await orderRepository.AddAsync(order);

                return new ServiceResponse<Guid>(order.Id);
            }
        }
    }
}
