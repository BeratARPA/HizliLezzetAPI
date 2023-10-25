using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.RestaurantTableSection.GetById
{
    public class GetRestaurantTableSectionByIdQuery : IRequest<ServiceResponse<RestaurantTableSectionViewDto>>
    {
        public Guid Id { get; set; }

        public class GetRestaurantTableSectionByIdQueryHandler : IRequestHandler<GetRestaurantTableSectionByIdQuery, ServiceResponse<RestaurantTableSectionViewDto>>
        {
            private readonly IRestaurantTableSectionRepository restaurantTableSectionRepository;
            private readonly IMapper mapper;

            public GetRestaurantTableSectionByIdQueryHandler(IRestaurantTableSectionRepository restaurantTableSectionRepository, IMapper mapper)
            {
                this.restaurantTableSectionRepository = restaurantTableSectionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<RestaurantTableSectionViewDto>> Handle(GetRestaurantTableSectionByIdQuery request, CancellationToken cancellationToken)
            {
                var restaurantTableSection = await restaurantTableSectionRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<RestaurantTableSectionViewDto>(restaurantTableSection);

                return new ServiceResponse<RestaurantTableSectionViewDto>(viewModel);
            }
        }
    }
}
