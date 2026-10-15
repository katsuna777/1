using DemoExam2026.Forms;
using DemoExam2026.Data;
using DemoExam2026.Services;

namespace DemoExam2026;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();
            DbInitializer.SeedDemoUser(db);
        }

        Application.Run(new LoginForm());
    }
}
