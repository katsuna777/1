using DemoExam2026.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam2026.Data;

public sealed class AppDbContext : DbContext
{
    private const string ConnectionString =
        "Server=localhost;Port=3306;Database=DemoExam2026;User=root;Password=;";

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            ConnectionString,
            ServerVersion.AutoDetect(ConnectionString));
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
