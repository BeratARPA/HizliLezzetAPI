using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Payment.DeleteById
{
    public class DeletePaymentByIdCommand : IRequest<ServiceResponse<PaymentViewDto>>
    {
        public Guid Id { get; set; }

        public class DeletePaymentByIdCommandHandler : IRequestHandler<DeletePaymentByIdCommand, ServiceResponse<PaymentViewDto>>
        {
            private readonly IPaymentRepository paymentRepository;
            private readonly IMapper mapper;

            public DeletePaymentByIdCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                this.paymentRepository = paymentRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<PaymentViewDto>> Handle(DeletePaymentByIdCommand request, CancellationToken cancellationToken)
            {
                var payment = await paymentRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<PaymentViewDto>(payment);

                return new ServiceResponse<PaymentViewDto>(viewModel);
            }
        }
    }
}
