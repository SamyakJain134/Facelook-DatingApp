using DatingAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace DatingAppAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return; //Dont have any users

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json"); //string of json text
            //var users = JsonSerializer.Deserialize<List<AppUser>>(userData); //deserialize in json object
            var users = JsonConvert.DeserializeObject<List<AppUser>>(userData);
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                user.PasswordSalt = hmac.Key;
               context.Users.Add(user); //no need to use awaitr and async as we are not dealing with database but justb adding some values

            }
            await context.SaveChangesAsync();
        }
    }
}
