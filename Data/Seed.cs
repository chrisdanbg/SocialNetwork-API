using System.Collections.Generic;
using Newtonsoft.Json;
using WebApp.API.Models;

namespace WebApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;

        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/userDataSeed.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var user in users)
            {
                byte[] passwordHash, passwortSalt;
                CreatePasswordHash("password", out passwordHash, out passwortSalt);
                
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwortSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
           
        }
    }
}