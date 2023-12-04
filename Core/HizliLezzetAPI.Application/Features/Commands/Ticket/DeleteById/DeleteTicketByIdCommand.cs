using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Ticket.DeleteById
{
    public class DeleteTicketByIdCommand : IRequest<ServiceResponse<TicketViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteTicketByIdCommandHandler : IRequestHandler<DeleteTicketByIdCommand, ServiceResponse<TicketViewDto>>
        {
            private readonly ITicketRepository ticketRepository;
            private readonly IMapper mapper;

            public DeleteTicketByIdCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                this.ticketRepository = ticketRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<TicketViewDto>> Handle(DeleteTicketByIdCommand request, CancellationToken cancellationToken)
            {
                var ticket = await ticketRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<TicketViewDto>(ticket);

                return new ServiceResponse<TicketViewDto>(viewModel);
            }
        }
    }
}
