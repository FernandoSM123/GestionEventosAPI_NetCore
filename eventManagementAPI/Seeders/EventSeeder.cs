using Bogus;
using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Seeders
{
    public static class EventSeeder
    {
        public static void Seed(ApplicationDbContext context, int numOfEvents)
        {
            if (!context.Events.Any())
            {
                var faker = new Faker();
                var events = new List<Event>();
                var districts = context.Districts.ToList();
                var cantons = context.Cantons.ToList();
                var provinces = context.Provinces.ToList();

                for (int i = 1; i <= numOfEvents; i++)
                {
                    int daysToAdd = faker.Random.Number(0, 3);
                    int monthsToAdd = faker.Random.Number(0, 3);

                    //generar dia random del mes actual
                    DateTime now = DateTime.Now;
                    int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                    int randomDay = faker.Random.Number(1, daysInMonth);
                    DateTime randomDate = new DateTime(now.Year, now.Month, randomDay);

                    //configurar fecha de inicio
                    DateTime startDate = randomDate.AddMonths(monthsToAdd);

                    //configurar fecha de finalizacion
                    DateTime endDate = startDate.AddDays(daysToAdd);

                    //configurar hora de inicio
                    int randomHour1 = faker.Random.Number(0, 11);
                    TimeSpan startingTime = new TimeSpan(randomHour1, 0, 0);

                    //configurar hora de finalizacion
                    int randomHour2 = faker.Random.Number(13, 23);
                    TimeSpan finishingTime = new TimeSpan(randomHour2, 0, 0);

                    // Generar provincia, canton, distrito random
                    var district = faker.PickRandom(districts);
                    var canton = cantons.FirstOrDefault(c => c.id == district.cantonId);
                    var province = provinces.FirstOrDefault(p => p.id == canton?.provinceId);

                    events.Add(new Event
                    {
                        name = string.Join(" ", faker.Lorem.Words(2)),
                        description = faker.Lorem.Sentence(),
                        details = faker.Lorem.Paragraph(),
                        exactPlace = faker.Address.StreetAddress(),
                        provinceId = province?.id ?? 1,
                        cantonId = canton?.id ?? 1,
                        districtId = district.id,
                        startingTime = startingTime,
                        finishingTime = finishingTime,
                        startDate = startDate,
                        endDate = endDate,
                    });
                }
                context.Events.AddRange(events);
                context.SaveChanges();
            }
        }
    }
}
