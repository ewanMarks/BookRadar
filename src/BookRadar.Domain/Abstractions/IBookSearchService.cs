using BookRadar.Domain.Entities;

namespace BookRadar.Domain.Abstractions;

public interface IBookSearchService
{
    Task<IReadOnlyList<Book>> SearchByAuthorAsync(string author, CancellationToken ct = default);
}
