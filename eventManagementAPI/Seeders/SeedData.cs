using eventManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Seeders
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                try
                {
                    //Ejecutar seeders
                    UserTypeSeeder.Seed(context);     
                    UserSeeder.Seed(context,50);
                    ProvinceSeeder.Seed(context);
                    CantonSeeder.Seed(context);
                    DistrictSeeder.Seed(context);
                    EventSeeder.Seed(context, 50);
                    RoleSeeder.Seed(context, 50);
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();
                    logger.LogError(ex, "Ocurrió un error durante el seeding de la base de datos.");
                }
            }
        }
    }
}
