namespace BookRadar.Domain.Entities;

public sealed record SearchHistory(
    long Id,
    string Author,
    string Title,
    int? PublicationYear,
    string? Publisher,
    DateTime SearchedAt);
