using AutoMapper;
using HizliLezzetAPI.Application.Features.Commands.Product.Create;
using HizliLezzetAPI.Application.Features.Commands.Product.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Product.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.Create;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.UpdateById;

namespace HizliLezzetAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //Product Mapping
            CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.Product, DeleteProductByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Product, UpdateProductCommand>()
             .ReverseMap();

            //Restaurant Mapping
            CreateMap<Domain.Entities.Restaurant, Dtos.RestaurantViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Restaurant, CreateRestaurantCommand>()
              .ReverseMap();
            CreateMap<Domain.Entities.Restaurant, DeleteRestaurantByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Restaurant, UpdateRestaurantCommand>()
             .ReverseMap();
        }
    }
}
