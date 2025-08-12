using BookRadar.Application.Dtos.Book;
using BookRadar.Application.Dtos.History;
using BookRadar.Domain.Entities;
using Mapster;

namespace BookRadar.Application.Mapping;

public sealed class ApplicationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Book, BookDto>();
        config.NewConfig<SearchHistory, SearchHistoryDto>();
    }
}
