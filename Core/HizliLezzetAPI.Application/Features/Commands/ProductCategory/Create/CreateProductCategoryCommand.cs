using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.ProductCategory.Create
{
    public class CreateProductCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid RestaurantId { get; set; }
        public bool PreperationType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ServiceResponse<Guid>>
        {
            private readonly IProductCategoryRepository productCategoryRepository;
            private readonly IMapper mapper;

            public CreateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                this.productCategoryRepository = productCategoryRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var productCategory = mapper.Map<Domain.Entities.ProductCategory>(request);
                await productCategoryRepository.AddAsync(productCategory);

                return new ServiceResponse<Guid>(productCategory.Id);
            }
        }
    }
}
