using BookRadar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadar.Domain.Abstractions;

public interface ISearchHistoryRepository
{
    Task AddRangeAsync(IEnumerable<SearchHistory> items, CancellationToken ct = default);
    Task<IReadOnlyList<SearchHistory>> GetRecentAsync(int take, CancellationToken ct = default);
    Task<bool> ExistsSameAuthorAndTitleWithinAsync(string author, string title, TimeSpan window, CancellationToken ct = default);
}
