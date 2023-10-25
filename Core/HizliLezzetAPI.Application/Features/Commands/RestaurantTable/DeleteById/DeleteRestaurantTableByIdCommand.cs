using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.RestaurantTable.DeleteById
{
    public class DeleteRestaurantTableByIdCommand : IRequest<ServiceResponse<RestaurantTableViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteRestaurantTableByIdCommandHandler : IRequestHandler<DeleteRestaurantTableByIdCommand, ServiceResponse<RestaurantTableViewDto>>
        {
            private readonly IRestaurantTableRepository restaurantTableRepository;
            private readonly IMapper mapper;

            public DeleteRestaurantTableByIdCommandHandler(IRestaurantTableRepository restaurantTableRepository, IMapper mapper)
            {
                this.restaurantTableRepository = restaurantTableRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<RestaurantTableViewDto>> Handle(DeleteRestaurantTableByIdCommand request, CancellationToken cancellationToken)
            {
                var restaurantTable = await restaurantTableRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<RestaurantTableViewDto>(restaurantTable);

                return new ServiceResponse<RestaurantTableViewDto>(viewModel);
            }
        }
    }
}
