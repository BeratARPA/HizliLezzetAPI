using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Payment.UpdateById
{
    public class UpdatePaymentCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string TerminalName { get; set; }
        public string TerminaIPAddress { get; set; }
        public decimal Amount { get; set; }
        public decimal TenderedAmount { get; set; }

        public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, ServiceResponse<Guid>>
        {
            private readonly IPaymentRepository paymentRepository;
            private readonly IMapper mapper;

            public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                this.paymentRepository = paymentRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
            {
                var existingPayment = await paymentRepository.GetByIdAsync(request.Id);
                mapper.Map(request, existingPayment);
                await paymentRepository.UpdateAsync(existingPayment);

                return new ServiceResponse<Guid>(existingPayment.Id);
            }
        }
    }
}
