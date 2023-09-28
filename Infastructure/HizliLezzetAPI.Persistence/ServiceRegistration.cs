using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Persistence.Context;
using HizliLezzetAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HizliLezzetAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQLLocalConnection"));
            });

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();           
        }
    }
}
