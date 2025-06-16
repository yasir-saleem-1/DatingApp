using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.Users.AnyAsync())
        {
            return;
        }
        var userData = File.ReadAllText("Data/UserSeedData.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        if (users == null) return;

        foreach (var user in users)
        {
            user.UserName = user.UserName.ToLower();
            user.Password = "Pa$$w0rd"; // Set a simple password
            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }
}