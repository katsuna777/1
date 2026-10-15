using DemoExam2026.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam2026.Data;

public sealed class AppDbContext : DbContext
{
    private const string DefaultConnectionString =
        "Server=31.76.12.103;Port=3306;Database=DemoExam2026;User=root;Password=;";

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DEMOEXAM2026_MYSQL_CONNECTION_STRING")
            ?? DefaultConnectionString;

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString));
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
