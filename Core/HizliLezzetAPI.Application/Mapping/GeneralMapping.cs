using AutoMapper;
using HizliLezzetAPI.Application.Features.Commands.CreateProduct;

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
        }
    }
}
