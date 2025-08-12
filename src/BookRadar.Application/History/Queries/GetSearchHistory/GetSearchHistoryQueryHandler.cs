using BookRadar.Application.Dtos.History;
using BookRadar.Domain.Abstractions;
using MapsterMapper;
using MediatR;

namespace BookRadar.Application.History.Queries.GetSearchHistory;

public sealed class GetSearchHistoryQueryHandler(
    ISearchHistoryRepository historyRepository,
    IMapper mapper)
    : IRequestHandler<GetSearchHistoryQuery, IReadOnlyList<SearchHistoryDto>>
{
    public async Task<IReadOnlyList<SearchHistoryDto>> Handle(GetSearchHistoryQuery request, CancellationToken ct)
    {
        var data = await historyRepository.GetRecentAsync(request.Take, ct);
        return mapper.Map<IReadOnlyList<SearchHistoryDto>>(data);
    }
}
