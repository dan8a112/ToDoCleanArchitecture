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

        modelBuilder.Entity<Activity>() // Una Activity tiene un user
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.UserId);
        
        modelBuilder.Entity<Activity>() // Una Activity tiene un type
            .HasOne(a => a.ActivityType)
            .WithMany()
            .HasForeignKey(a => a.ActivityTypeId);
        
        modelBuilder.Entity<Task>() // Una task tiene una actividad
            .HasOne(t => t.Activity)
            .WithMany()
            .HasForeignKey(t => t.ActivityId);
        
    }
}