using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Restaurant.DeleteById
{
    public class DeleteRestaurantByIdCommand : IRequest<ServiceResponse<RestaurantViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteRestaurantByIdCommandHandler : IRequestHandler<DeleteRestaurantByIdCommand, ServiceResponse<RestaurantViewDto>>
        {
            private readonly IRestaurantRepository restaurantRepository;
            private readonly IMapper mapper;

            public DeleteRestaurantByIdCommandHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
            {
                this.restaurantRepository = restaurantRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<RestaurantViewDto>> Handle(DeleteRestaurantByIdCommand request, CancellationToken cancellationToken)
            {
                var restaurant = await restaurantRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<RestaurantViewDto>(restaurant);

                return new ServiceResponse<RestaurantViewDto>(viewModel);
            }
        }
    }
}
