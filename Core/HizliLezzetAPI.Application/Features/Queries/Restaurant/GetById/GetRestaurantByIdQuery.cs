using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.Product.GetById
{
    public class GetRestaurantByIdQuery : IRequest<ServiceResponse<RestaurantViewDto>>
    {
        public Guid Id { get; set; }

        public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, ServiceResponse<RestaurantViewDto>>
        {
            private readonly IRestaurantRepository restaurantRepository;
            private readonly IMapper mapper;

            public GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
            {
                this.restaurantRepository = restaurantRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<RestaurantViewDto>> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
            {
                var restaurant = await restaurantRepository.GetByIdAsync(request.Id);

                var viewModel = mapper.Map<RestaurantViewDto>(restaurant);

                return new ServiceResponse<RestaurantViewDto>(viewModel);
            }
        }
    }
}
