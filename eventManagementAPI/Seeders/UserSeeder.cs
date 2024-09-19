namespace eventManagementAPI.Seeders;
using Bogus;

using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

public static class UserSeeder
{
    public static void Seed(ApplicationDbContext context, int numberOfUsers)
    {
        var faker = new Faker();
        var users = new List<User>();

        if (!context.Users.Any())
        {
            for (int i = 1; i <= numberOfUsers; i++)
            {
                if (i == 1)
                {
                    users.Add(new User
                    {
                        username = "John",
                        lastname = "Doe",
                        cellphone = "123456789",
                        email = "John@gmail.com",
                        password = BCrypt.Net.BCrypt.HashPassword("123"),
                        userTypeId = 1
                    });
                }

                else
                {
                    users.Add(new User
                    {
                        username = faker.Internet.UserName(),
                        lastname = faker.Name.LastName(),
                        cellphone = faker.Phone.PhoneNumber(),
                        email = faker.Internet.Email(),
                        password = BCrypt.Net.BCrypt.HashPassword("123"),
                        userTypeId = faker.Random.Int(1, 2) // Asigna aleatoriamente entre 'Administrator' (1) y 'Viewer' (2)
                    });
                }
            }

            context.Users.AddRange(users);

            context.SaveChanges();
        }

    }
}
