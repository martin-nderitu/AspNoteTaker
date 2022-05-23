using Microsoft.EntityFrameworkCore;

namespace NoteTaker.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) {}

    public DbSet<Note> Notes => Set<Note>();

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return (await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken));
    }

    private void AddTimestamps()
    {
        var entityEntries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && e.State is EntityState.Added or EntityState.Modified);
        
        var utcNow = DateTime.UtcNow;

        foreach (var entityEntry in entityEntries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = utcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = utcNow;
            }
        }
    }
}