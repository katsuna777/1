using DemoExam2026.Data;
using DemoExam2026.Models;

namespace DemoExam2026.Services;

public sealed class AuthService
{
    public User? Authenticate(string login, string password)
    {
        using var db = new AppDbContext();

        return db.Users.FirstOrDefault(user =>
            user.Login == login && user.Password == password);
    }
}
