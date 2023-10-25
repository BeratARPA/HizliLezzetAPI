using AutoMapper;
using HizliLezzetAPI.Application.Dtos;
using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Wrappers;
using MediatR;

namespace HizliLezzetAPI.Application.Features.Queries.RestaurantTableSection.GetAll
{
    public class GetAllRestaurantTableSectionsQuery : IRequest<ServiceResponse<List<RestaurantTableSectionViewDto>>>
    {
        public class GetAllRestaurantTableSectionsQueryHandler : IRequestHandler<GetAllRestaurantTableSectionsQuery, ServiceResponse<List<RestaurantTableSectionViewDto>>>
        {
            private readonly IRestaurantTableSectionRepository restaurantTableSectionRepository;
            private readonly IMapper mapper;

            public GetAllRestaurantTableSectionsQueryHandler(IRestaurantTableSectionRepository restaurantTableSectionRepository, IMapper mapper)
            {
                this.restaurantTableSectionRepository = restaurantTableSectionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<RestaurantTableSectionViewDto>>> Handle(GetAllRestaurantTableSectionsQuery request, CancellationToken cancellationToken)
            {
                var restaurantTableSections = await restaurantTableSectionRepository.GetAllAsync();

                var viewModel = mapper.Map<List<RestaurantTableSectionViewDto>>(restaurantTableSections);

                return new ServiceResponse<List<RestaurantTableSectionViewDto>>(viewModel);
            }
        }
    }
}
