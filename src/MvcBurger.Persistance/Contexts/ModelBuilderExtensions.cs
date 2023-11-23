using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcBurger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBurger.Persistance.Contexts
{
    public static class ModelBuilderExtensions
    {

        private const string adminRoleId = "93c64b50-ed6a-4055-9498-ea449d4138dd";
        private const string adminUserId = "85bf13d3-5471-44c4-a8db-a28e67e39484";

        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "password123";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();
            adminRole.Id = adminRoleId;

            builder.Entity<IdentityRole>().HasData(adminRole);

            var adminUser = new AppUser
            {
                Id = adminUserId,
                Firstname = "first",
                Lastname = "last",
                UserName = "aa@aa.aa",
                Email = "aa@aa.aa",
                EmailConfirmed = true,
                Address = ""
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            builder.Entity<AppUser>().HasData(adminUser);



            var userRole = new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);

        }
    }
}

