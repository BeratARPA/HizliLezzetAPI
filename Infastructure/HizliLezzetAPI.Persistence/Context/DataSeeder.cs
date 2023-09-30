using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HizliLezzetAPI.Persistence.Context
{
    public static class DataSeeder
    {
        public async static void Initialize(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            using (var context = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var random = new Random();

                #region RestaurantOwners
                var restaurantOwners = new List<RestaurantOwner>
                {
                    new RestaurantOwner
                    {
                        Id = Guid.NewGuid()
                    },
                    new RestaurantOwner
                    {
                        Id = Guid.NewGuid()
                    }
                };

                if (!context.RestaurantOwners.Any())
                {
                    await context.RestaurantOwners.AddRangeAsync(restaurantOwners);
                }
                #endregion

                var restaurants = new List<Restaurant>();
                foreach (var restaurantOwner in restaurantOwners)
                {
                    #region Restaurants                   
                    for (int i = 1; i <= 3; i++)
                    {
                        Restaurant restaurant = new Restaurant
                        {
                            Id = Guid.NewGuid(),
                            RestaurantOwnerId = restaurantOwner.Id,
                            Title = $"Restaurant {i}",
                            Description = $"Description {i}",
                            Thumbnail = $"Thumbnail{i}.jpg",
                            Longitude = (decimal)(random.NextDouble() * 180 - 90),
                            Latitude = (decimal)(random.NextDouble() * 360 - 180),
                            PhoneNumber = $"555-555-55-5{i}",
                            Email = $"Restaurant{i}@example.com",
                            Address = $"Address {i}",
                            WorkingStatus = $"Working Status {i}",
                            IsActive = i % 2 == 0,
                            DayOfWeek = $"Day of Week {i}",
                            OpeningTime = DateTime.Now.AddHours(random.Next(1, 12)),
                            ClosingTime = DateTime.Now.AddHours(random.Next(13, 23)),
                            CreationDate = DateTime.Now.AddHours(-i),
                            LastModifiedDate = DateTime.Now.AddHours(-i * 2),
                            IsActiveWeb = i % 2 == 1,
                            IsActiveLocal = i % 2 == 0,
                            IsActiveGetirYemek = i % 2 == 1,
                            IsActiveYemekSepeti = i % 2 == 0,
                            IsActiveMigrosYemek = i % 2 == 1,
                            IsActiveTrendyolYemek = i % 2 == 0
                        };

                        restaurants.Add(restaurant);
                    }

                    if (!context.Restaurants.Any())
                    {
                        await context.Restaurants.AddRangeAsync(restaurants);
                    }
                    #endregion
                }

                foreach (var restaurant in restaurants)
                {
                    #region ProductCategories
                    var productCategories = new List<ProductCategory>();

                    for (int i = 1; i <= 3; i++)
                    {
                        ProductCategory category = new ProductCategory
                        {
                            Id = Guid.NewGuid(),
                            RestaurantId = restaurant.Id,
                            PreperationType = i % 2 == 0,
                            Title = $"Category {i}",
                            Description = $"Description {i}",
                            Thumbnail = $"Thumbnail{i}.jpg"
                        };

                        productCategories.Add(category);
                    }

                    if (!context.ProductCategories.Any())
                    {
                        await context.ProductCategories.AddRangeAsync(productCategories);
                    }
                    #endregion

                    foreach (var productCategory in productCategories)
                    {
                        #region Products
                        var products = new List<Product>();

                        for (int i = 1; i <= 10; i++)
                        {
                            Product product = new Product
                            {
                                Id = Guid.NewGuid(),
                                RestaurantId = restaurant.Id,
                                ProductCategoryId = productCategory.Id,
                                Kcal = random.Next(100, 1000),
                                PreperationTime = random.Next(10, 60).ToString(),
                                Title = $"Product {i}",
                                Price = (decimal)random.NextDouble() * 50,
                                Rating = (decimal)(random.NextDouble() * 5),
                                Thumbnail = $"Product{i}.jpg",
                                IsActiveWeb = i % 2 == 0,
                                IsActiveLocal = i % 2 == 1,
                                IsActiveGetirYemek = i % 2 == 0,
                                IsActiveYemekSepeti = i % 2 == 1,
                                IsActiveMigrosYemek = i % 2 == 0,
                                IsActiveTrendyolYemek = i % 2 == 1
                            };

                            products.Add(product);
                        }

                        if (!context.Products.Any())
                        {
                            await context.Products.AddRangeAsync(products);
                        }
                        #endregion
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
