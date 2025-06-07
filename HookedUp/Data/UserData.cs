using HookedUp.Models;

namespace HookedUp.Data
{
    public class UserData
    {
        public static List<User> Users = new()
        {
            new User
            {
                Id = 1,
                Name = "Sirena Foster",
                Email = "sirenafoster@example.com",
                Password = "password123",
                Role = "user",
                ProfilePicture = "https://example.com/sirenafoster.jpg",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new User
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Password = "password456",
                Role = "artist",
                ProfilePicture = "https://example.com/janesmith.jpg",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new User
            {
                Id = 3,
                Name = "Sienna Delmar",
                Email = "sienna.delmar@example.com",
                Password = "password789",
                Role = "user",
                ProfilePicture = "https://example.com/siennadelmar.jpg",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new User
            {
                Id = 4,
                Name = "Sophia Garcia",
                Email = "sophia.garcia@example.com",
                Password = "password000",
                Role = "artist",
                ProfilePicture = "https://example.com/sophiagarcia.jpg",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new User
            {
                Id = 5,
                Name = "Iris Huxley",
                Email = "iris.huxley@example.com",
                Password = "password321",
                Role = "artist",
                ProfilePicture = "https://example.com/irishuxley.jpg",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
