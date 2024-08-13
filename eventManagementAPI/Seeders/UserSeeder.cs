namespace eventManagementAPI.Seeders;
using Bogus;

using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

public static class UserSeeder
{
    public static void Seed(ModelBuilder modelBuilder, int numberOfUsers)
    {
        var faker = new Faker();
        var users = new List<User>();

        for (int i = 1; i <= numberOfUsers; i++)
        {
            users.Add(new User
            {
                id = i,
                username = faker.Internet.UserName(),
                lastname = faker.Name.LastName(),
                cellphone = faker.Phone.PhoneNumber(),
                email = faker.Internet.Email(),
                password = BCrypt.Net.BCrypt.HashPassword("123"),
                userTypeId = faker.Random.Int(1, 2) // Asigna aleatoriamente entre 'Administrator' (1) y 'Viewer' (2)
            });
        }
        modelBuilder.Entity<User>().HasData(users);
    }
}
