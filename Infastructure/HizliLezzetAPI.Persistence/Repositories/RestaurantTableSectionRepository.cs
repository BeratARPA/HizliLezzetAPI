using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class RestaurantTableSectionRepository : GenericRepository<RestaurantTableSection>, IRestaurantTableSectionRepository
    {
        public RestaurantTableSectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
