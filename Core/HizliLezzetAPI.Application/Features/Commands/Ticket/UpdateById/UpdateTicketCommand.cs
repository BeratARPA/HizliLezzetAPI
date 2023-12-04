using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Ticket.UpdateById
{
    public class UpdateTicketCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
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

        public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, ServiceResponse<Guid>>
        {
            private readonly ITicketRepository ticketRepository;
            private readonly IMapper mapper;

            public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                this.ticketRepository = ticketRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
            {
                var existingTicket = await ticketRepository.GetByIdAsync(request.Id);
                mapper.Map(request, existingTicket);
                await ticketRepository.UpdateAsync(existingTicket);

                return new ServiceResponse<Guid>(existingTicket.Id);
            }
        }
    }
}
