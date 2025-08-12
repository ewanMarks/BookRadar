namespace BookRadar.Application.Dtos.History;

public sealed record SearchHistoryDto(
    long Id,
    string Author,
    string Title,
    int? PublicationYear,
    string? Publisher,
    DateTime SearchedAt);