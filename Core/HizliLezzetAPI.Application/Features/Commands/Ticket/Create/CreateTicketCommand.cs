using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Ticket.Create
{
    public class CreateTicketCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid RestaurantId { get; set; }
        public Guid RestaurantTableId { get; set; }
        public string TicketNumber { get; set; }
        public bool IsOpened { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public string Note { get; set; }
        public string CreatedUserName { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public DateTime LastOrderDateTime { get; set; }
        public DateTime LastPaymentDateTime { get; set; }

        public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ServiceResponse<Guid>>
        {
            private readonly ITicketRepository ticketRepository;
            private readonly IMapper mapper;

            public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                this.ticketRepository = ticketRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
            {
                var ticket = mapper.Map<Domain.Entities.Ticket>(request);
                await ticketRepository.AddAsync(ticket);

                return new ServiceResponse<Guid>(ticket.Id);
            }
        }
    }
}
