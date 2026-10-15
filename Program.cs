using DemoExam2026.Forms;

namespace DemoExam2026;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.Run(new LoginForm());
    }
}
