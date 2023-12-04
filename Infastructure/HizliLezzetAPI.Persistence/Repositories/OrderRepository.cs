using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
