using DemoExam2026.Models;

namespace DemoExam2026.Data;

internal static class DbInitializer
{
    public static void SeedDemoUser(AppDbContext db)
    {
        if (db.Users.Any())
            return;

        db.Users.Add(new User
        {
            Fio = "Пользователь",
            Login = "user",
            Password = "user",
            Role = UserRole.AuthorizedClient
        });

        db.SaveChanges();
    }
}
