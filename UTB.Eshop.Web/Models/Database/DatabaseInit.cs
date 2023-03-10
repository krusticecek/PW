using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;

namespace UTB.Eshop.Web.Models.Database
{
    public class DatabaseInit
    {
        public List<CarouselItem> CreateCarouselItems()
        {
            List<CarouselItem> carouselItems = new List<CarouselItem>();

            CarouselItem ci1 = new CarouselItem()
            {
                ID = 1,
                ImageSrc = "/img/carousel/information-technology-1.jpg",
                ImageAlt = "First slide"
            };

            CarouselItem ci2 = new CarouselItem()
            {
                ID = 2,
                ImageSrc = "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg",
                ImageAlt = "Second slide"
            };

            CarouselItem ci3 = new CarouselItem()
            {
                ID = 3,
                ImageSrc = "/img/carousel/1581481407499.jpeg",
                ImageAlt = "Third slide"
            };

            CarouselItem ci4 = new CarouselItem()
            {
                ID = 4,
                ImageSrc = "/img/carousel/talisman.jpg",
                ImageAlt = "Forth slide"
            };


            carouselItems.Add(ci1);
            carouselItems.Add(ci2);
            carouselItems.Add(ci3);
            carouselItems.Add(ci4);

            return carouselItems;
        }

        public List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();


            Product cs1 = new Product()
            {
                ID = 1,
                Name = "One Piece Manga",
                Price = 250,
                ImageSrc = "/img/products/op.jpg",
                ImageAlt = "One piece manga"

            };

            Product cs2 = new Product()
            {
                ID = 2,
                Name = "Naruto Manga",
                Price = 225,
                ImageSrc = "/img/products/naruto.jpg",
                ImageAlt = "Naruto manga"


            };

            Product cs3 = new Product()
            {
                ID = 3,
                Name = "Bleach Manga",
                Price = 200,
                ImageSrc = "/img/products/bleach.jpg",
                ImageAlt = "Bleach manga"


            };

            Product cs4 = new Product()
            {
                ID = 4,
                Name = "Blue Lock Manga",
                Price = 230,
                ImageSrc = "/img/products/blue_lock.jpg",
                ImageAlt = "Blue Lock manga"


            };

            Product cs5 = new Product()
            {
                ID = 5,
                Name = "Attack on titan Manga",
                Price = 350,
                ImageSrc = "/img/products/aot.jpg",
                ImageAlt = "Attack on titan manga"


            };

            products.Add(cs1);
            products.Add(cs2);
            products.Add(cs3);
            products.Add(cs4);
            products.Add(cs5);

            return products;
        }
        public List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role roleCustomer = new Role()
            {
                Id = 3,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };

            Role roleMember = new Role()
            {
                Id = 4,
                Name = "Member",
                NormalizedName = "MEMBER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-477awdawdawd"
            };

            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(roleCustomer);
            roles.Add(roleMember);

            return roles;
        }


        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }


        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }

        public List<Membership> CreateMemberships()
        {
            List<Membership> memberships = new List<Membership>();


            Membership ms1 = new Membership()
            {
                Id = 1,
                Name = "Customer",
                Discount = 5,
                Status = 0,
            };

            Membership ms2 = new Membership()
            {
                Id = 2,
                Name = "Member",
                Discount = 5,
                Status = 1,

            };

            Membership ms3 = new Membership()
            {
                Id = 3,
                Name = "Manager",
                Discount = 15,
                Status = 1,


            };


            memberships.Add(ms1);
            memberships.Add(ms2);
            memberships.Add(ms3);


            return memberships;
        }
    }
}
