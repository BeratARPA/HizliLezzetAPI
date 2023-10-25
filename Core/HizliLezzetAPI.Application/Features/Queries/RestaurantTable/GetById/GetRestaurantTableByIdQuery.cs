using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.RestaurantTable.GetById
{
    public class GetRestaurantTableByIdQuery : IRequest<ServiceResponse<RestaurantTableViewDto>>
    {
        public Guid Id { get; set; }

        public class GetRestaurantTableByIdQueryHandler : IRequestHandler<GetRestaurantTableByIdQuery, ServiceResponse<RestaurantTableViewDto>>
        {
            private readonly IRestaurantTableRepository restaurantTableRepository;
            private readonly IMapper mapper;

            public GetRestaurantTableByIdQueryHandler(IRestaurantTableRepository restaurantTableRepository, IMapper mapper)
            {
                this.restaurantTableRepository = restaurantTableRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<RestaurantTableViewDto>> Handle(GetRestaurantTableByIdQuery request, CancellationToken cancellationToken)
            {
                var restaurantTable = await restaurantTableRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<RestaurantTableViewDto>(restaurantTable);

                return new ServiceResponse<RestaurantTableViewDto>(viewModel);
            }
        }
    }
}
