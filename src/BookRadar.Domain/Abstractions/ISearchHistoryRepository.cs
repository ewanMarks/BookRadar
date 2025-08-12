using BookRadar.Domain.Entities;

namespace BookRadar.Domain.Abstractions;

public interface ISearchHistoryRepository
{
    Task AddRangeAsync(IEnumerable<SearchHistory> items, CancellationToken ct = default);
    Task<IReadOnlyList<SearchHistory>> GetRecentAsync(int take, CancellationToken ct = default);
    Task<bool> ExistsSameAuthorAndTitleWithinAsync(string author, string title, TimeSpan window, CancellationToken ct = default);
}
