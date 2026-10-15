using DemoExam2026.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam2026.Data;

public sealed class AppDbContext : DbContext
{
    private static string GetConnectionString() =>
        Environment.GetEnvironmentVariable("DEMOEXAM2026_MYSQL_CONNECTION_STRING")
        ?? throw new InvalidOperationException(
            "Set the DEMOEXAM2026_MYSQL_CONNECTION_STRING environment variable.");

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = GetConnectionString();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.Entity<User>()
            .Property(user => user.Role)
            .HasConversion<string>();
    }
}
