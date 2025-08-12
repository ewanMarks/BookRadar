namespace BookRadar.Web.ViewModels.History;

public sealed record SearchHistoryViewModel(
    long Id,
    string Author,
    string Title,
    int? PublicationYear,
    string? Publisher,
    DateTime SearchedAt);
