using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.DeleteById
{
    public class DeleteRestaurantTableSectionByIdCommand : IRequest<ServiceResponse<RestaurantTableSectionViewDto>>
    {
        public Guid Id { get; set; }

        public class DeleteRestaurantTableSectionByIdCommandHandler : IRequestHandler<DeleteRestaurantTableSectionByIdCommand, ServiceResponse<RestaurantTableSectionViewDto>>
        {
            private readonly IRestaurantTableSectionRepository restaurantTableSectionRepository;
            private readonly IMapper mapper;

            public DeleteRestaurantTableSectionByIdCommandHandler(IRestaurantTableSectionRepository restaurantTableSectionRepository, IMapper mapper)
            {
                this.restaurantTableSectionRepository = restaurantTableSectionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<RestaurantTableSectionViewDto>> Handle(DeleteRestaurantTableSectionByIdCommand request, CancellationToken cancellationToken)
            {
                var restaurantTableSection = await restaurantTableSectionRepository.DeleteByIdAsync(request.Id);

                var viewModel = mapper.Map<RestaurantTableSectionViewDto>(restaurantTableSection);

                return new ServiceResponse<RestaurantTableSectionViewDto>(viewModel);
            }
        }
    }
}
