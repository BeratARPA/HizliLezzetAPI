using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Payment.Create
{
    public class CreatePaymentCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public decimal Amount { get; set; }
        public decimal TenderedAmount { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, ServiceResponse<Guid>>
        {
            private readonly IPaymentRepository paymentRepository;
            private readonly IMapper mapper;

            public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                this.paymentRepository = paymentRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                var payment = mapper.Map<Domain.Entities.Payment>(request);
                await paymentRepository.AddAsync(payment);

                return new ServiceResponse<Guid>(payment.Id);
            }
        }
    }
}
