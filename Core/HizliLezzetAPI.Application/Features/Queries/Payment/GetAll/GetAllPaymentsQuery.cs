using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Payment.GetAll
{
    public class GetAllPaymentsQuery : IRequest<ServiceResponse<List<PaymentViewDto>>>
    {
        public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, ServiceResponse<List<PaymentViewDto>>>
        {
            private readonly IPaymentRepository paymentRepository;
            private readonly IMapper mapper;

            public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
            {
                this.paymentRepository = paymentRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<PaymentViewDto>>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
            {
                var payments = await paymentRepository.GetAllAsync();

                var viewModel = mapper.Map<List<PaymentViewDto>>(payments);

                return new ServiceResponse<List<PaymentViewDto>>(viewModel);
            }
        }
    }
}
