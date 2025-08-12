using BookRadar.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookRadar.Infrastructure.Persistence.Context;

public sealed class BookRadarDbContext(DbContextOptions<BookRadarDbContext> options)
    : DbContext(options)
{
    public DbSet<SearchHistoryEntity> SearchHistories => Set<SearchHistoryEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookRadarDbContext).Assembly);
    }
}
