namespace BookRadar.Infrastructure.Persistence.Entities;

public sealed class SearchHistoryEntity
{
    public long Id { get; set; }
    public string Author { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int? PublicationYear { get; set; }
    public string? Publisher { get; set; }
    public DateTime SearchedAt { get; set; }
}
