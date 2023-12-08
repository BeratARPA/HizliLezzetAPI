using AutoMapper;
using HizliLezzetAPI.Application.Features.Commands.Order.Create;
using HizliLezzetAPI.Application.Features.Commands.Order.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Order.UpdateById;
using HizliLezzetAPI.Application.Features.Commands.Payment.Create;
using HizliLezzetAPI.Application.Features.Commands.Payment.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Payment.UpdateById;
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
using HizliLezzetAPI.Application.Features.Commands.Ticket.Create;
using HizliLezzetAPI.Application.Features.Commands.Ticket.DeleteById;
using HizliLezzetAPI.Application.Features.Commands.Ticket.UpdateById;

namespace HizliLezzetAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //Product Mapping
            CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>()
                .ForMember(dest => dest.ProductMaterials, opt => opt.MapFrom(src => src.ProductMaterials))
                .ForMember(dest => dest.ActiveMaterials, opt => opt.MapFrom(src => src.ActiveMaterials))
                .ForMember(dest => dest.LimitedMaterials, opt => opt.MapFrom(src => src.LimitedMaterials))
                .ForMember(dest => dest.AdditionalSections, opt => opt.MapFrom(src => src.AdditionalSections))
                .ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>()
                .ReverseMap();
            CreateMap<Domain.Entities.Product, DeleteProductByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Product, UpdateProductCommand>()
             .ReverseMap();

            //ProductMaterials Mapping
            CreateMap<Domain.Entities.ProductMaterial, Dtos.ProductMaterialViewDto>()
                .ReverseMap();

            //ActiveMaterials Mapping
            CreateMap<Domain.Entities.ActiveMaterial, Dtos.ActiveMaterialViewDto>()
                .ReverseMap();

            //LimitedMaterials Mapping
            CreateMap<Domain.Entities.LimitedMaterial, Dtos.LimitedMaterialViewDto>()
                .ReverseMap();

            //AdditionalSections Mapping
            CreateMap<Domain.Entities.AdditionalSection, Dtos.AdditionalSectionViewDto>()
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

            //Order Mapping
            CreateMap<Domain.Entities.Order, Dtos.OrderViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Order, CreateOrderCommand>()
              .ReverseMap();
            CreateMap<Domain.Entities.Order, DeleteOrderByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Order, UpdateOrderCommand>()
             .ReverseMap();

            //Ticket Mapping
            CreateMap<Domain.Entities.Ticket, Dtos.TicketViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Ticket, CreateTicketCommand>()
              .ReverseMap();
            CreateMap<Domain.Entities.Ticket, DeleteTicketByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Ticket, UpdateTicketCommand>()
             .ReverseMap();

            //Payment Mapping
            CreateMap<Domain.Entities.Payment, Dtos.PaymentViewDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Payment, CreatePaymentCommand>()
              .ReverseMap();
            CreateMap<Domain.Entities.Payment, DeletePaymentByIdCommand>()
             .ReverseMap();
            CreateMap<Domain.Entities.Payment, UpdatePaymentCommand>()
             .ReverseMap();
        }
    }
}
