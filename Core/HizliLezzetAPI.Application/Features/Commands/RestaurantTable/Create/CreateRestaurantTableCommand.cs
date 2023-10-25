using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.RestaurantTable.Create
{
    public class CreateRestaurantTableCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid RestaurantTableSectionId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public class CreateRestaurantTableCommandHandler : IRequestHandler<CreateRestaurantTableCommand, ServiceResponse<Guid>>
        {
            private readonly IRestaurantTableRepository restaurantTableRepository;
            private readonly IMapper mapper;

            public CreateRestaurantTableCommandHandler(IRestaurantTableRepository restaurantTableRepository, IMapper mapper)
            {
                this.restaurantTableRepository = restaurantTableRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateRestaurantTableCommand request, CancellationToken cancellationToken)
            {
                var restaurantTable = mapper.Map<Domain.Entities.RestaurantTable>(request);
                await restaurantTableRepository.AddAsync(restaurantTable);

                return new ServiceResponse<Guid>(restaurantTable.Id);
            }
        }
    }
}
