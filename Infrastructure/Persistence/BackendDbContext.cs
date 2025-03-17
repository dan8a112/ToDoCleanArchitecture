using Domain.AggregateRoots;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure.Persistence;

public class BackendDbContext : DbContext
{
    public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User ||--o{ Activity
        modelBuilder.Entity<Activity>()
            .HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserId);
        
        // ActivityType ||--o{ Activity
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.ActivityType)
            .WithMany()
            .HasForeignKey(a => a.ActivityTypeId);
        
        // Activity ||--o{ Task
        modelBuilder.Entity<Task>()
            .HasOne(a => a.Activity)
            .WithMany()
            .HasForeignKey(a => a.ActivityId);
        
    }
}