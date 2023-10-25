using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.ProductCategory.GetById
{
    public class GetProductCategoryByIdQuery : IRequest<ServiceResponse<ProductCategoryViewDto>>
    {
        public Guid Id { get; set; }

        public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ServiceResponse<ProductCategoryViewDto>>
        {
            private readonly IProductCategoryRepository productCategoryRepository;
            private readonly IMapper mapper;

            public GetProductCategoryByIdQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                this.productCategoryRepository = productCategoryRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<ProductCategoryViewDto>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var productCategory = await productCategoryRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<ProductCategoryViewDto>(productCategory);

                return new ServiceResponse<ProductCategoryViewDto>(viewModel);
            }
        }
    }
}
