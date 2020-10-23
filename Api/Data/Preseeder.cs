using Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class Preseeder
    {

        public static async Task Seeder(AppDbContext ctx, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            ctx.Database.EnsureCreated();

            if (!roleManager.Roles.Any())
            {
                var listOfRoles = new List<IdentityRole>
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("Employee")
                };

                foreach (var role in listOfRoles)
                {
                    await roleManager.CreateAsync(role);
                }
            }

            if (!userManager.Users.Any())
            {
                var listOfUsers = new List<ApplicationUser>
                {
                    new ApplicationUser{ UserName="yemi@mail.com", Email = "yemi@mail.com", LastName="Onibokun", FirstName="Yemi", Photo = "avatar.jpg" },
                    new ApplicationUser{ UserName="kk@mail.com", Email = "kk@mail.com", LastName="Kkk", FirstName="Kkk", Photo = "avatar.jpg" }
                };

                int counter = 0;
                foreach (var user in listOfUsers)
                {
                    var result = await userManager.CreateAsync(user, "P@$$word1");

                    if (result.Succeeded)
                    {
                        if (counter == 0)
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            await userManager.AddToRoleAsync(user, "Employee");
                        }
                    }
                    counter++;
                }
            }
        }
    }

}
