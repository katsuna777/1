namespace DemoExam2026.Models;

public enum UserRole
{
    AuthorizedClient,
    Manager,
    Administrator
}

public sealed class User
{
    public int Id { get; set; }
    public string Fio { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
