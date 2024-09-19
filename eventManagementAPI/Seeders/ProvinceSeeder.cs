using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Seeders
{
    public static class ProvinceSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Provinces.Any())
            {

                var provinces = new List<Province> {
                new Province { code = 1, name = "San José" },
                new Province { code = 2, name = "Alajuela" },
                new Province { code = 3, name = "Cartago" },
                new Province { code = 4, name = "Heredia" },
                new Province { code = 5, name = "Guanacaste" },
                new Province { code = 6, name = "Puntarenas" },
                new Province { code = 7, name = "Limón" }
                };

                context.Provinces.AddRange(provinces);
                context.SaveChanges();
            }
        }
    }
}
