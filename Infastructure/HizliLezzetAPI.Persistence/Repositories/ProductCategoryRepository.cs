using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
