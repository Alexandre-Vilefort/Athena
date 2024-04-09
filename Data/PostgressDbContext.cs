using Microsoft.EntityFrameworkCore;
using Athena.Models;

namespace Athena.Data;

public class PostgressDbContext : DbContext
{
    public PostgressDbContext(DbContextOptions<PostgressDbContext> options) : base(options) 
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Customer> Customers { get; set; }

    // public override int SaveChanges()
    // {
    //     AddTimestamps();
    //     return base.SaveChanges();
    // }

    // public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    // {
    //     AddTimestamps();
    //     return await base.SaveChangesAsync(cancellationToken);
    // }

    // private void AddTimestamps()
    // {
    //     var entities = ChangeTracker.Entries()
    //         .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

    //     foreach (var entity in entities)
    //     {
    //         var now = DateTime.UtcNow; // current datetime

    //         if (entity.State == EntityState.Added)
    //         {
    //             ((BaseEntity)entity.Entity).CreatedAt = now;
    //             ((BaseEntity)entity.Entity).UpdatedAt = now;
    //         }

    //         ((BaseEntity)entity.Entity).UpdatedAt = now;
    //     }
    // }
}