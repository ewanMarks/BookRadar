using BookRadar.Domain.Abstractions;
using BookRadar.Domain.Entities;
using BookRadar.Infrastructure.Persistence.Context;
using BookRadar.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookRadar.Infrastructure.Repositories.History;

public sealed class SearchHistoryRepository(BookRadarDbContext db) : ISearchHistoryRepository
{
    public async Task AddRangeAsync(IEnumerable<SearchHistory> items, CancellationToken ct = default)
    {
        var rows = items.Select(x => new SearchHistoryEntity
        {
            Author = x.Author,
            Title = x.Title,
            PublicationYear = x.PublicationYear,
            Publisher = x.Publisher,
            SearchedAt = x.SearchedAt
        });

        await db.SearchHistories.AddRangeAsync(rows, ct);
        await db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<SearchHistory>> GetRecentAsync(int take, CancellationToken ct = default)
    {
        var data = await db.SearchHistories
            .AsNoTracking()
            .OrderByDescending(x => x.SearchedAt)
            .Take(take)
            .ToListAsync(ct);

        return data.Select(x => new SearchHistory(
            x.Id, x.Author, x.Title, x.PublicationYear, x.Publisher, x.SearchedAt)).ToList();
    }

    public async Task<bool> ExistsSameAuthorAndTitleWithinAsync(string author, string title, TimeSpan window, CancellationToken ct = default)
    {
        var from = DateTime.UtcNow - window;
        return await db.SearchHistories
            .AsNoTracking()
            .AnyAsync(x => x.Author == author && x.Title == title && x.SearchedAt >= from, ct);
    }
}
