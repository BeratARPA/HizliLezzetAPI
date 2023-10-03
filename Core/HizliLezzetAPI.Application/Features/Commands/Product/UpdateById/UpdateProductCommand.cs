using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Product.UpdateById
{
    public class UpdateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid RestaurantId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public decimal Kcal { get; set; }
        public string PreperationTime { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Thumbnail { get; set; }
        public bool IsActiveWeb { get; set; }
        public bool IsActiveLocal { get; set; }
        public bool IsActiveGetirYemek { get; set; }
        public bool IsActiveYemekSepeti { get; set; }
        public bool IsActiveMigrosYemek { get; set; }
        public bool IsActiveTrendyolYemek { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var updatedProduct = mapper.Map<Domain.Entities.Product>(request);
                await productRepository.UpdateAsync(updatedProduct);

                return new ServiceResponse<Guid>(updatedProduct.Id);
            }
        }
    }
}
