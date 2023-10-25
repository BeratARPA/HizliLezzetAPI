using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.ProductCategory.UpdateById
{
    public class UpdateProductCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid RestaurantId { get; set; }
        public bool PreperationType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ServiceResponse<Guid>>
        {
            private readonly IProductCategoryRepository productCategoryRepository;
            private readonly IMapper mapper;

            public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                this.productCategoryRepository = productCategoryRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var updatedProductCategory = mapper.Map<Domain.Entities.ProductCategory>(request);
                await productCategoryRepository.UpdateAsync(updatedProductCategory);

                return new ServiceResponse<Guid>(updatedProductCategory.Id);
            }
        }
    }
}
