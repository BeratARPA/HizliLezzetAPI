using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Product.GetAll
{
    public class GetAllRestaurantsQuery : IRequest<ServiceResponse<List<RestaurantViewDto>>>
    {
        public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, ServiceResponse<List<RestaurantViewDto>>>
        {
            private readonly IRestaurantRepository restaurantRepository;
            private readonly IMapper mapper;

            public GetAllRestaurantsQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
            {
                this.restaurantRepository = restaurantRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<RestaurantViewDto>>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
            {
                var restaurants = await restaurantRepository.GetAllAsync();

                var viewModel = mapper.Map<List<RestaurantViewDto>>(restaurants);

                return new ServiceResponse<List<RestaurantViewDto>>(viewModel);
            }
        }
    }
}
