using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.Create
{
    public class CreateRestaurantTableSectionCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid RestaurantId { get; set; }
        public char TableKeyword { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public class CreateRestaurantTableSectionCommandHandler : IRequestHandler<CreateRestaurantTableSectionCommand, ServiceResponse<Guid>>
        {
            private readonly IRestaurantTableSectionRepository restaurantTableSectionRepository;
            private readonly IMapper mapper;

            public CreateRestaurantTableSectionCommandHandler(IRestaurantTableSectionRepository restaurantTableSectionRepository, IMapper mapper)
            {
                this.restaurantTableSectionRepository = restaurantTableSectionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateRestaurantTableSectionCommand request, CancellationToken cancellationToken)
            {
                var restaurantTableSection = mapper.Map<Domain.Entities.RestaurantTableSection>(request);
                await restaurantTableSectionRepository.AddAsync(restaurantTableSection);

                return new ServiceResponse<Guid>(restaurantTableSection.Id);
            }
        }
    }
}
