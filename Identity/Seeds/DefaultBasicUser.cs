using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //seed default admin user
            var defaultUser = new ApplicationUser
            {
                UserName = "UserBasic",
                Email = "userBasic@mail.com",
                Name = "Helder",
                Surname = "Guerra",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "$123Password");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }

        }
    }
}
