using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.ProductCategory.GetAll
{
    public class GetAllProductCategoriesQuery : IRequest<ServiceResponse<List<ProductCategoryViewDto>>>
    {
        public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, ServiceResponse<List<ProductCategoryViewDto>>>
        {
            private readonly IProductCategoryRepository productCategoryRepository;
            private readonly IMapper mapper;

            public GetAllProductCategoriesQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                this.productCategoryRepository = productCategoryRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductCategoryViewDto>>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
            {
                var productCategories = await productCategoryRepository.GetAllAsync();

                var viewModel = mapper.Map<List<ProductCategoryViewDto>>(productCategories);

                return new ServiceResponse<List<ProductCategoryViewDto>>(viewModel);
            }
        }
    }
}
