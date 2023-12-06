using HizliLezzetAPI.Domain.Entities;
using HizliLezzetAPI.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DataSeeder
{
    public static async void Initialize(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        using (var context = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
            await SeedCustomerUserAsync(userManager);

            await SeedDataAsync(context, userManager);
        }
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        if (!await roleManager.RoleExistsAsync("Customer"))
            await roleManager.CreateAsync(new IdentityRole("Customer"));
    }

    private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
    {
        if (userManager.FindByEmailAsync("admin@example.com").Result == null)
        {
            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "adminuser",
                Email = "admin@example.com",
                FirstName = "Admin",
                LastName = "User"
            };

            IdentityResult createAdminUser = await userManager.CreateAsync(adminUser, "Admin123!");

            if (createAdminUser.Succeeded)
            {
                //await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }

    private static async Task SeedCustomerUserAsync(UserManager<ApplicationUser> userManager)
    {
        if (userManager.FindByEmailAsync("customer@example.com").Result == null)
        {
            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customeruser",
                Email = "customer@example.com",
                FirstName = "Customer",
                LastName = "User"
            };

            IdentityResult createCustomerUser = await userManager.CreateAsync(customerUser, "Customer123!");

            if (createCustomerUser.Succeeded)
            {
                //await userManager.AddToRoleAsync(customerUser, "Customer");
            }
        }
    }

    private static async Task SeedDataAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        var random = new Random();

        if (!context.RestaurantOwners.Any())
        {
            #region RestaurantOwners
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            var customerUser = await userManager.FindByEmailAsync("customer@example.com");
            var restaurantOwners = new List<RestaurantOwner>
            {
                new RestaurantOwner
                {
                    Id = Guid.NewGuid(),
                    UserId = adminUser.Id
                },
                new RestaurantOwner
                {
                    Id = Guid.NewGuid(),
                    UserId = customerUser.Id
                }
            };

            await context.RestaurantOwners.AddRangeAsync(restaurantOwners);
            await context.SaveChangesAsync();

            foreach (var restaurantOwner in restaurantOwners)
            {
                #region Restaurants
                for (int i = 1; i <= 2; i++)
                {
                    Restaurant restaurant = new Restaurant
                    {
                        Id = Guid.NewGuid(),
                        RestaurantOwnerId = restaurantOwner.Id,
                        Title = $"Restaurant {i}",
                        // ... 
                    };

                    var restaurantTableSections = new List<RestaurantTableSection>();
                    for (int j = 1; j <= 2; j++)
                    {
                        RestaurantTableSection section = new RestaurantTableSection
                        {
                            Id = Guid.NewGuid(),
                            RestaurantId = restaurant.Id,
                            TableKeyword = (char)('A' + j - 1),
                            Title = $"Section {j}",
                            // ... 
                        };

                        var restaurantTables = new List<RestaurantTable>();
                        for (int k = 1; k <= 5; k++)
                        {
                            RestaurantTable table = new RestaurantTable
                            {
                                Id = Guid.NewGuid(),
                                RestaurantTableSectionId = section.Id,
                                Name = $"Table {k}",
                                // ... 
                            };

                            restaurantTables.Add(table);
                        }

                        section.RestaurantTables = restaurantTables;
                        restaurantTableSections.Add(section);
                    }

                    restaurant.RestaurantTableSections = restaurantTableSections;

                    await context.Restaurants.AddAsync(restaurant);
                    await context.SaveChangesAsync();

                    #region ProductCategories
                    var productCategories = new List<ProductCategory>();
                    for (int l = 1; l <= 5; l++)
                    {
                        ProductCategory category = new ProductCategory
                        {
                            Id = Guid.NewGuid(),
                            RestaurantId = restaurant.Id,
                            PreperationType = l % 2 == 0,
                            Title = $"Category {l}",
                            Description = $"Description {l}",
                            Thumbnail = $"Thumbnail{l}.jpg"
                        };

                        productCategories.Add(category);
                    }

                    await context.ProductCategories.AddRangeAsync(productCategories);
                    await context.SaveChangesAsync();
                    #endregion

                    #region Products
                    var products = new List<Product>();
                    foreach (var productCategory in productCategories)
                    {
                        for (int m = 1; m <= 5; m++)
                        {
                            Product product = new Product
                            {
                                Id = Guid.NewGuid(),
                                RestaurantId = restaurant.Id,
                                ProductCategoryId = productCategory.Id,
                                Kcal = random.Next(100, 1000),
                                PreperationTime = random.Next(10, 60).ToString(),
                                Title = $"Product {m}",
                                Price = (decimal)random.NextDouble() * 50,
                                Rating = (decimal)(random.NextDouble() * 5),
                                Thumbnail = $"Product{m}.jpg",
                                IsActiveWeb = m % 2 == 0,
                                IsActiveLocal = m % 2 == 1,
                                IsActiveGetirYemek = m % 2 == 0,
                                IsActiveYemekSepeti = m % 2 == 1,
                                IsActiveMigrosYemek = m % 2 == 0,
                                IsActiveTrendyolYemek = m % 2 == 1
                            };

                            var productMaterials = new List<ProductMaterial>();
                            for (int n = 1; n <= 3; n++)
                            {
                                ProductMaterial material = new ProductMaterial
                                {
                                    Id = Guid.NewGuid(),
                                    RestaurantId = restaurant.Id,
                                    ProductId = product.Id,
                                    Title = $"Material {n}",
                                    // ... 
                                };

                                productMaterials.Add(material);
                            }

                            product.ProductMaterials = productMaterials;

                            var activeMaterials = new List<ActiveMaterial>();
                            for (int o = 1; o <= 2; o++)
                            {
                                ActiveMaterial activeMaterial = new ActiveMaterial
                                {
                                    Id = Guid.NewGuid(),
                                    ProductId = product.Id,
                                    Name = $"Active Material {o}",
                                    // ... 
                                };

                                activeMaterials.Add(activeMaterial);
                            }

                            product.ActiveMaterials = activeMaterials;

                            var limitedMaterials = new List<LimitedMaterial>();
                            for (int p = 1; p <= 3; p++)
                            {
                                LimitedMaterial limitedMaterial = new LimitedMaterial
                                {
                                    Id = Guid.NewGuid(),
                                    ProductId = product.Id,
                                    Name = $"Limited Material {p}",
                                    // ...
                                };

                                limitedMaterials.Add(limitedMaterial);
                            }

                            product.LimitedMaterials = limitedMaterials;

                            var additionalSections = new List<AdditionalSection>();
                            for (int q = 1; q <= 2; q++)
                            {
                                AdditionalSection additionalSection = new AdditionalSection
                                {
                                    Id = Guid.NewGuid(),
                                    ProductId = product.Id,
                                    // ... 
                                };

                                additionalSections.Add(additionalSection);
                            }

                            product.AdditionalSections = additionalSections;
                            products.Add(product);
                        }
                    }

                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                    #endregion
                }
                #endregion
            }
            #endregion
        }
    }
}