using AutoMapper;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Commands.Restaurant.Create
{
    public class CreateRestaurantCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public bool IsActiveWeb { get; set; }
        public bool IsActiveLocal { get; set; }
        public bool IsActiveGetirYemek { get; set; }
        public bool IsActiveYemekSepeti { get; set; }
        public bool IsActiveMigrosYemek { get; set; }
        public bool IsActiveTrendyolYemek { get; set; }

        public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ServiceResponse<Guid>>
        {
            private readonly IRestaurantRepository restaurantRepository;
            private readonly IMapper mapper;

            public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
            {
                this.restaurantRepository = restaurantRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
            {
                var restaurant = mapper.Map<Domain.Entities.Restaurant>(request);
                await restaurantRepository.AddAsync(restaurant);

                return new ServiceResponse<Guid>(restaurant.Id);
            }
        }
    }
}
