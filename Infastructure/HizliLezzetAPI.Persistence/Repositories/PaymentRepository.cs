using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;

namespace HizliLezzetAPI.Persistence.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
