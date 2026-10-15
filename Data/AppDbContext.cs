using DemoExam2026.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam2026.Data;

public sealed class AppDbContext : DbContext
{
    private static readonly string DatabaseDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "DemoExam2026");

    private static readonly string DatabasePath = Path.Combine(DatabaseDirectory, "demoexam2026.db");

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Directory.CreateDirectory(DatabaseDirectory);
        optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
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
