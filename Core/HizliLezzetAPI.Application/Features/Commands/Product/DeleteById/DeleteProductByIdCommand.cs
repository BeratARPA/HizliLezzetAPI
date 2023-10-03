using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Product.DeleteById
{
    public class DeleteProductByIdCommand : IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, ServiceResponse<ProductViewDto>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public DeleteProductByIdCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<ProductViewDto>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var product = await productRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<ProductViewDto>(product);

                return new ServiceResponse<ProductViewDto>(viewModel);
            }
        }
    }
}
