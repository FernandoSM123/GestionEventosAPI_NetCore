using Bogus;
using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Seeders
{
    public static class UserTypeSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.UserTypes.Any())
            {

                context.UserTypes.AddRange(
                      new UserType { name = "Admin", description = "Administrator role" },
                      new UserType { name = "User", description = "Standard user role" }
                  );

                context.SaveChanges();
            }
        }
    }
}
