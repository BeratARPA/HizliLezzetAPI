using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync(bool includeRelatedEntities = false)
        {
            var query = dbContext.Products.AsQueryable();

            if (includeRelatedEntities)
            {
                query = query
                    .Include(p => p.ProductMaterials)
                    .Include(p => p.ActiveMaterials)
                    .Include(p => p.LimitedMaterials)
                    .Include(p => p.AdditionalSections);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id, bool includeRelatedEntities = false)
        {
            var query = dbContext.Products.AsQueryable();

            if (includeRelatedEntities)
            {
                query = query
                    .Include(p => p.ProductMaterials)
                    .Include(p => p.ActiveMaterials)
                    .Include(p => p.LimitedMaterials)
                    .Include(p => p.AdditionalSections);
            }

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
