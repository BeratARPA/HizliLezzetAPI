using AutoMapper;
using HizliLezzetAPI.Application.Features.Commands.Product.Create;
using HizliLezzetAPI.Application.Features.Commands.Product.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Product.UpdateById;

namespace HizliLezzetAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.Product, DeleteProductByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Product, UpdateProductCommand>()
             .ReverseMap();
        }
    }
}
