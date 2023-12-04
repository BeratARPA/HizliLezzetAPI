using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Ticket.GetById
{
    public class GetTicketByIdQuery : IRequest<ServiceResponse<TicketViewDto>>
    {
        public Guid Id { get; set; }

        public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, ServiceResponse<TicketViewDto>>
        {
            private readonly ITicketRepository ticketRepository;
            private readonly IMapper mapper;

            public GetTicketByIdQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                this.ticketRepository = ticketRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<TicketViewDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
            {
                var ticket = await ticketRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<TicketViewDto>(ticket);

                return new ServiceResponse<TicketViewDto>(viewModel);
            }
        }
    }
}
