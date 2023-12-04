using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.RestaurantTable.UpdateById
{
    public class UpdateRestaurantTableCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public Guid RestaurantTableSectionId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public class UpdateRestaurantTableCommandHandler : IRequestHandler<UpdateRestaurantTableCommand, ServiceResponse<Guid>>
        {
            private readonly IRestaurantTableRepository restaurantTableRepository;
            private readonly IMapper mapper;

            public UpdateRestaurantTableCommandHandler(IRestaurantTableRepository restaurantTableRepository, IMapper mapper)
            {
                this.restaurantTableRepository = restaurantTableRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateRestaurantTableCommand request, CancellationToken cancellationToken)
            {
                var existingRestaurantTable = await restaurantTableRepository.GetByIdAsync(request.Id);
                mapper.Map(request, existingRestaurantTable);
                await restaurantTableRepository.UpdateAsync(existingRestaurantTable);

                return new ServiceResponse<Guid>(existingRestaurantTable.Id);
            }
        }
    }
}
