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
            serviceCollection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            serviceCollection.AddTransient<IRestaurantRepository, RestaurantRepository>();
            serviceCollection.AddTransient<IRestaurantTableRepository, RestaurantTableRepository>();
            serviceCollection.AddTransient<IRestaurantTableSectionRepository, RestaurantTableSectionRepository>();
            serviceCollection.AddTransient<ISecretsRepositoryAsync, AzureKeyVaultRepository>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<ITicketRepository, TicketRepository>();
            serviceCollection.AddTransient<IPaymentRepository, PaymentRepository>();
        }
    }
}
