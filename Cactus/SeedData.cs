using CactusDomain.Models;
using Microsoft.AspNetCore.Identity;

namespace Cactus
{
    public class SeedData
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("admin"))
                    await roleManager.CreateAsync(new IdentityRole("admin"));
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new IdentityRole("user"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "mehreganabdix@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "mehregan",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            FullAddress="TestAddress",
                            PostalCode = "TestPodtalCode"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, "admin");
                }

            }
        }
    }
}
