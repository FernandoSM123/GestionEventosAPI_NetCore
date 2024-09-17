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
                new Province { id = 1, name = "San José" },
                new Province { id = 2, name = "Alajuela" },
                new Province { id = 3, name = "Cartago" },
                new Province { id = 4, name = "Heredia" },
                new Province { id = 5, name = "Guanacaste" },
                new Province { id = 6, name = "Puntarenas" },
                new Province { id = 7, name = "Limón" }
                };

                context.Provinces.AddRange(provinces);
                context.SaveChanges();
            }
        }
    }
}
