using BookRadar.Application.Dtos.History;
using MediatR;

namespace BookRadar.Application.History.Queries.GetSearchHistory;

public sealed record GetSearchHistoryQuery(int Take = 50) : IRequest<IReadOnlyList<SearchHistoryDto>>;