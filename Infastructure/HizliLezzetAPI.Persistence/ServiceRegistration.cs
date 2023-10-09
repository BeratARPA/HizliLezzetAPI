using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HizliLezzetAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<IRestaurantRepository, RestaurantRepository>();                      
            serviceCollection.AddTransient<ISecretsRepositoryAsync, AzureKeyVaultRepository>();                      
        }
    }
}
