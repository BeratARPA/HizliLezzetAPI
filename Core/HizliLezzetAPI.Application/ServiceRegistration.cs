using HizliLezzetAPI.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HizliLezzetAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            serviceCollection.AddAutoMapper(assembly);
            serviceCollection.AddMediatR(assembly);
            serviceCollection.AddTransient<JwtTokenGenerator>();
        }
    }
}
