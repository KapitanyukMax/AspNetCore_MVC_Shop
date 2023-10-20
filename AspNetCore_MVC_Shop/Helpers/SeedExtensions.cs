using System;
using DataAccess.Entities;
using AspNetCore_MVC_Shop.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Shop_MVC_VPD_121.Helpers
{
    public static class SeedExtensions
    {
        public static async Task SeedRoles(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdmin(this IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            const string USERNAME = "admin@admin.com";
            const string PASSWORD = "Admin_1";

            var existingUser = await userManager.FindByNameAsync(USERNAME);

            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = USERNAME,
                    Email = USERNAME,
                };

                var result = await userManager.CreateAsync(user, PASSWORD);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                }
            }
        }
    }
}