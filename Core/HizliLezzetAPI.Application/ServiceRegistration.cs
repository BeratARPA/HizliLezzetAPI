﻿using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Application.Mapping;
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
            serviceCollection.AddAutoMapper(typeof(GeneralMapping));
            serviceCollection.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));     
            
            serviceCollection.AddTransient<JwtTokenGenerator>();
            serviceCollection.AddTransient<IUserAccessor, UserAccessor>();            
        }
    }
}
