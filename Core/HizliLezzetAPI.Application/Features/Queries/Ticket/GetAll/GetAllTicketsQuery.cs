using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Ticket.GetAll
{
    public class GetAllTicketsQuery : IRequest<ServiceResponse<List<TicketViewDto>>>
    {
        public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, ServiceResponse<List<TicketViewDto>>>
        {
            private readonly ITicketRepository ticketRepository;
            private readonly IMapper mapper;

            public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                this.ticketRepository = ticketRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<TicketViewDto>>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
            {
                var tickets = await ticketRepository.GetAllAsync();

                var viewModel = mapper.Map<List<TicketViewDto>>(tickets);

                return new ServiceResponse<List<TicketViewDto>>(viewModel);
            }
        }
    }
}
