using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Database.Configuration;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;

namespace UTB.Eshop.Web.Models.Database
{
    public class EshopDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<CarouselItem> CarouselItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public EshopDbContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().Replace("AspNet", String.Empty));
            }

            DatabaseInit databaseInit = new DatabaseInit();
            builder.Entity<CarouselItem>().HasData(databaseInit.CreateCarouselItems());
            builder.Entity<Product>().HasData(databaseInit.CreateProducts());

            builder.Entity<Role>().HasData(databaseInit.CreateRoles());
            
            // vytvoření memberships 
            builder.Entity<Membership>().HasData(databaseInit.CreateMemberships());

            (User admin, List<IdentityUserRole<int>> adminRole) = databaseInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerRole) = databaseInit.CreateManagerWithRoles();

            builder.Entity<User>().HasData(admin, manager);
            builder.Entity<IdentityUserRole<int>>().HasData(adminRole);
            builder.Entity<IdentityUserRole<int>>().HasData(managerRole);

            builder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}
