using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class RestaurantTableRepository : GenericRepository<RestaurantTable>, IRestaurantTableRepository
    {
        public RestaurantTableRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
