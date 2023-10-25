using AutoMapper;
using HizliLezzetAPI.Application.Features.Commands.Product.Create;
using HizliLezzetAPI.Application.Features.Commands.Product.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Product.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.Create;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.ProductCategory.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.Create;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Restaurant.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTable.Create;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTable.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTable.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.Create;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.UpdateById;

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

            //ProductCategory Mapping
            CreateMap<Domain.Entities.ProductCategory, Dtos.ProductCategoryViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.ProductCategory, CreateProductCategoryCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.ProductCategory, DeleteProductCategoryByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.ProductCategory, UpdateProductCategoryCommand>()
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

            //RestaurantTable Mapping
            CreateMap<Domain.Entities.RestaurantTable, Dtos.RestaurantTableViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.RestaurantTable, CreateRestaurantTableCommand>()
              .ReverseMap();
            CreateMap<Domain.Entities.RestaurantTable, DeleteRestaurantTableByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.RestaurantTable, UpdateRestaurantTableCommand>()
             .ReverseMap();

            //RestaurantTableSection Mapping
            CreateMap<Domain.Entities.RestaurantTableSection, Dtos.RestaurantTableSectionViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.RestaurantTableSection, CreateRestaurantTableSectionCommand>()
              .ReverseMap();
            CreateMap<Domain.Entities.RestaurantTableSection, DeleteRestaurantTableSectionByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.RestaurantTableSection, UpdateRestaurantTableSectionCommand>()
             .ReverseMap();
        }
    }
}
