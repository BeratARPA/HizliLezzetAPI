using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Payment.GetById
{
    public class GetPaymentByIdQuery : IRequest<ServiceResponse<PaymentViewDto>>
    {
        public Guid Id { get; set; }

        public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, ServiceResponse<PaymentViewDto>>
        {
            private readonly IPaymentRepository paymentRepository;
            private readonly IMapper mapper;

            public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                this.paymentRepository = paymentRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<PaymentViewDto>> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
            {
                var payment = await paymentRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<PaymentViewDto>(payment);

                return new ServiceResponse<PaymentViewDto>(viewModel);
            }
        }
    }
}
