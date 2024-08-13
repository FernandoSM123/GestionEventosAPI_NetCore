using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Seeders
{
    public static class UserTypeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
                new UserType { id = 1, name = "Administrator", description = "User with full administrative rights" },
                new UserType { id = 2, name = "Viewer", description = "User with read-only access" }
            );
        }
    }
}
