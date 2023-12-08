using HizliLezzetAPI.Domain.Entities;

namespace HizliLezzetAPI.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
        Task<Product> GetByIdAsync(Guid id, bool includeRelatedEntities = false);
        Task<List<Product>> GetAllAsync(bool includeRelatedEntities = false);
    }
}
