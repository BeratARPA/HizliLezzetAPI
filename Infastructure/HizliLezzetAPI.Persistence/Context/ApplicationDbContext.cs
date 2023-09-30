using HizliLezzetAPI.Application.Interfaces.Repositories;
using HizliLezzetAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HizliLezzetAPI.Persistence.Context
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private readonly IUserAccessor userAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserAccessor userAccessor) : base(options)
        {
            this.userAccessor = userAccessor;
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }
        public virtual DbSet<RestaurantTableSection> RestaurantTableSections { get; set; }
        public virtual DbSet<SpecialProduct> SpecialProducts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////Adding user filter to Product class.
            //modelBuilder.Entity<Product>()
            //    .HasQueryFilter(p => p.AppUserId == currentUserId);

            ////Adding user filter to ProductCategory class.
            //modelBuilder.Entity<ProductCategory>()
            //    .HasQueryFilter(c => c.AppUserId == currentUserId);

            // Define the relationship between Order and Ticket
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Ticket)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TicketId);

            // Define the relationship between Payment and Ticket
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Ticket)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TicketId);

            // Define the relationship between Product and ProductCategory
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            // Define the relationship between ProductMaterial and Product
            modelBuilder.Entity<ProductMaterial>()
                .HasOne(pm => pm.Product)
                .WithMany(p => p.ProductMaterials)
                .HasForeignKey(pm => pm.ProductId);

            // Define the relationship between RestaurantTable and Restaurant
            modelBuilder.Entity<RestaurantTableSection>()
                .HasOne(rts => rts.Restaurant)
                .WithMany(r => r.RestaurantTableSections)
                .HasForeignKey(rts => rts.RestaurantId);

            // Define the relationship between RestaurantTable and RestaurantTableSection
            modelBuilder.Entity<RestaurantTable>()
                .HasOne(rt => rt.RestaurantTableSection)
                .WithMany(rts => rts.RestaurantTables)
                .HasForeignKey(rt => rt.RestaurantTableSectionId);

            // Define the relationship between SpecialProduct and Product
            modelBuilder.Entity<SpecialProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SpecialProducts)
                .HasForeignKey(sp => sp.ProductId);

            // Define the relationship between Ticket and Restaurant
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tickets)
                .HasForeignKey(t => t.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define the relationship between Ticket and RestaurantTable
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.RestaurantTable)
                .WithMany(rt => rt.Tickets)
                .HasForeignKey(t => t.RestaurantTableId);
        }
    }
}
