using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookRadar.Infrastructure.Persistence.Context;

public sealed class BookRadarDbContextFactory : IDesignTimeDbContextFactory<BookRadarDbContext>
{
    public BookRadarDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookRadarDbContext>();

        const string cs = "Server=(localdb)\\MSSQLLocalDB;Database=BookRadarDb.Dev;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(cs);

        return new BookRadarDbContext(optionsBuilder.Options);
    }
}
