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

        public virtual DbSet<ActiveMaterial> ActiveMaterials { get; set; }
        public virtual DbSet<AdditionalSection> AdditionalSections { get; set; }
        public virtual DbSet<LimitedMaterial> LimitedMaterials { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }
        public virtual DbSet<RestaurantTableSection> RestaurantTableSections { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ApplicationUser - RestaurantOwner relationship
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(au => au.RestaurantOwner)
                .WithOne(ro => ro.ApplicationUser)
                .HasForeignKey<RestaurantOwner>(ro => ro.UserId);

            // RestaurantOwner - Restaurant relationship
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.RestaurantOwner)
                .WithMany(ro => ro.Restaurants)
                .HasForeignKey(r => r.RestaurantOwnerId);

            // Restaurant - ProductCategory relationship
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Restaurant)
                .WithMany(r => r.ProductCategories)
                .HasForeignKey(pc => pc.RestaurantId);

            // Restaurant - Product relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Restaurant)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Restaurant - ProductMaterial relationship
            modelBuilder.Entity<ProductMaterial>()
                .HasOne(pc => pc.Restaurant)
                .WithMany(r => r.ProductMaterials)
                .HasForeignKey(pc => pc.RestaurantId);

            // ProductCategory - Product relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            // Product - ProductMaterial relationship
            modelBuilder.Entity<ProductMaterial>()
                .HasOne(pm => pm.Product)
                .WithMany(p => p.ProductMaterials)
                .HasForeignKey(pm => pm.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Restaurant - RestaurantTableSection relationship
            modelBuilder.Entity<RestaurantTableSection>()
                .HasOne(rts => rts.Restaurant)
                .WithMany(r => r.RestaurantTableSections)
                .HasForeignKey(rts => rts.RestaurantId);

            // RestaurantTableSection - RestaurantTable relationship
            modelBuilder.Entity<RestaurantTable>()
                .HasOne(rt => rt.RestaurantTableSection)
                .WithMany(rts => rts.RestaurantTables)
                .HasForeignKey(rt => rt.RestaurantTableSectionId);

            // Restaurant - Ticket relationship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tickets)
                .HasForeignKey(t => t.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            // RestaurantTable - Ticket relationship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.RestaurantTable)
                .WithMany(rt => rt.Tickets)
                .HasForeignKey(t => t.RestaurantTableId);

            // Ticket - Order relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Ticket)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TicketId);

            // Ticket - Payment relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Ticket)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TicketId);

            // ActiveMaterial - Product relationship
            modelBuilder.Entity<ActiveMaterial>()
                .HasOne(am => am.Product)
                .WithMany(p => p.ActiveMaterials)
                .HasForeignKey(am => am.ProductId);

            // AdditionalSection - Product relationship
            modelBuilder.Entity<AdditionalSection>()
                .HasOne(ads => ads.Product)
                .WithMany(p => p.AdditionalSections)
                .HasForeignKey(ads => ads.ProductId);

            // LimitedMaterial - Product relationship
            modelBuilder.Entity<LimitedMaterial>()
                .HasOne(lm => lm.Product)
                .WithMany(p => p.LimitedMaterials)
                .HasForeignKey(lm => lm.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
