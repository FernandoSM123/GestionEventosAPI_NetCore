using Bogus;
using eventManagementAPI.Data;
using eventManagementAPI.Models;

namespace eventManagementAPI.Seeders
{
    public class RoleSeeder
    {
        public static void Seed(ApplicationDbContext context, int numberOfRoles)
        {
            var faker = new Faker();
            var roles = new List<Role>();

            if (!context.Roles.Any())
            {
                for (int i = 1; i <= numberOfRoles; i++)
                {
                        roles.Add(new Role
                        {
                            name = faker.Name.JobTitle(),
                            descripcion = faker.Lorem.Sentence(),
                        });
                }

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

        }
    }
}
