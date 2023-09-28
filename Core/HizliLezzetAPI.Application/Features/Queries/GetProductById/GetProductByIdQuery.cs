using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<ProductViewDto>(product);

                return new ServiceResponse<ProductViewDto>(viewModel);
            }
        }
    }
}
