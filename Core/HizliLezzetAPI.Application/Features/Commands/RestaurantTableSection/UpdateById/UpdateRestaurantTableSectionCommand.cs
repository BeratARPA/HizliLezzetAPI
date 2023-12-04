using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.RestaurantTableSection.UpdateById
{
    public class UpdateRestaurantTableSectionCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public char TableKeyword { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

        public class UpdateRestaurantTableSectionCommandHandler : IRequestHandler<UpdateRestaurantTableSectionCommand, ServiceResponse<Guid>>
        {
            private readonly IRestaurantTableSectionRepository restaurantTableSectionRepository;
            private readonly IMapper mapper;

            public UpdateRestaurantTableSectionCommandHandler(IRestaurantTableSectionRepository restaurantTableSectionRepository, IMapper mapper)
            {
                this.restaurantTableSectionRepository = restaurantTableSectionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateRestaurantTableSectionCommand request, CancellationToken cancellationToken)
            {
                var existingRestaurantTableSection = await restaurantTableSectionRepository.GetByIdAsync(request.Id);
                mapper.Map(request, existingRestaurantTableSection);
                await restaurantTableSectionRepository.UpdateAsync(existingRestaurantTableSection);

                return new ServiceResponse<Guid>(existingRestaurantTableSection.Id);
            }
        }
    }
}
