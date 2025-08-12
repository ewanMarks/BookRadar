using BookRadar.Domain.Entities;
using BookRadar.Infrastructure.Http.Models;
using Mapster;

namespace BookRadar.Infrastructure.Mapping;

public sealed class OpenLibraryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OpenLibraryDoc, Book>()
              .Map(dest => dest.Title, src => src.Title ?? string.Empty)
              .Map(dest => dest.PublicationYear, src => src.FirstPublishYear)
              .Map(dest => dest.Publisher, src => src.Publisher != null && src.Publisher.Count > 0 ? src.Publisher[0] : null);
    }
}
