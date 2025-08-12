namespace BookRadar.Domain.Entities;

public sealed record Book(
    string Title,
    int? PublicationYear,
    string? Publisher);
