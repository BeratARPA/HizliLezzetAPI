using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Order.UpdateById
{
    public class UpdateOrderCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public decimal TotalPrice { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public string CreatedUserName { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ServiceResponse<Guid>>
        {
            private readonly IOrderRepository orderRepository;
            private readonly IMapper mapper;

            public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                this.orderRepository = orderRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                var existingOrder = await orderRepository.GetByIdAsync(request.Id);
                mapper.Map(request, existingOrder);
                await orderRepository.UpdateAsync(existingOrder);

                return new ServiceResponse<Guid>(existingOrder.Id);
            }
        }
    }
}
