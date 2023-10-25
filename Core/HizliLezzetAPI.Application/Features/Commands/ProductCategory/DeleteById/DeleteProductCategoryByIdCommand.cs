using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.ProductCategory.DeleteById
{
    public class DeleteProductCategoryByIdCommand : IRequest<ServiceResponse<ProductCategoryViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteProductCategoryByIdCommandHandler : IRequestHandler<DeleteProductCategoryByIdCommand, ServiceResponse<ProductCategoryViewDto>>
        {
            private readonly IProductCategoryRepository productCategoryRepository;
            private readonly IMapper mapper;

            public DeleteProductCategoryByIdCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                this.productCategoryRepository = productCategoryRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<ProductCategoryViewDto>> Handle(DeleteProductCategoryByIdCommand request, CancellationToken cancellationToken)
            {
                var productCategory = await productCategoryRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<ProductCategoryViewDto>(productCategory);

                return new ServiceResponse<ProductCategoryViewDto>(viewModel);
            }
        }
    }
}
