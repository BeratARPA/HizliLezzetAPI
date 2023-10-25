using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.RestaurantTable.GetAll
{
    public class GetAllRestaurantTablesQuery : IRequest<ServiceResponse<List<RestaurantTableViewDto>>>
    {
        public class GetAllRestaurantTablesQueryHandler : IRequestHandler<GetAllRestaurantTablesQuery, ServiceResponse<List<RestaurantTableViewDto>>>
        {
            private readonly IRestaurantTableRepository restaurantTableRepository;
            private readonly IMapper mapper;

            public GetAllRestaurantTablesQueryHandler(IRestaurantTableRepository restaurantTableRepository, IMapper mapper)
            {
                this.restaurantTableRepository = restaurantTableRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<RestaurantTableViewDto>>> Handle(GetAllRestaurantTablesQuery request, CancellationToken cancellationToken)
            {
                var restaurantTables = await restaurantTableRepository.GetAllAsync();

                var viewModel = mapper.Map<List<RestaurantTableViewDto>>(restaurantTables);

                return new ServiceResponse<List<RestaurantTableViewDto>>(viewModel);
            }
        }
    }
}
