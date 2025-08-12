using BookRadar.Application.Dtos.Book;
using BookRadar.Application.Dtos.History;
using BookRadar.Web.ViewModels.Book;
using BookRadar.Web.ViewModels.History;
using Mapster;

namespace BookRadar.Web.Mapping;

public sealed class WebMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BookDto, BookViewModel>();
        config.NewConfig<SearchHistoryDto, SearchHistoryViewModel>();
    }
}
