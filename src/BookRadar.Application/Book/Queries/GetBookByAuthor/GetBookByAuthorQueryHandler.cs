using BookRadar.Application.Dtos.Book;
using BookRadar.Domain.Abstractions;
using BookRadar.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace BookRadar.Application.Book.Queries.GetBookByAuthor;

public sealed class GetBooksByAuthorQueryHandler(
    IBookSearchService bookSearchService,
    ISearchHistoryRepository historyRepository,
    IMapper mapper)
    : IRequestHandler<GetBooksByAuthorQuery, IReadOnlyList<BookDto>>
{
    public async Task<IReadOnlyList<BookDto>> Handle(GetBooksByAuthorQuery request, CancellationToken ct)
    {
        // 1) Buscar en API externa (puerto de Dominio)
        var books = await bookSearchService.SearchByAuthorAsync(request.Author, ct);

        // 2) Mapear a DTO para la Web
        var result = mapper.Map<IReadOnlyList<BookDto>>(books);

        // 3) Guardar historial (evitar duplicados < 1 minuto)
        //    Se guarda 1 registro por libro, atando Autor + Título
        var now = DateTime.UtcNow;
        var toPersist = new List<SearchHistory>();
        foreach (var book in books)
        {
            var repeated = !string.IsNullOrWhiteSpace(book.Title)
                && await historyRepository.ExistsSameAuthorAndTitleWithinAsync(request.Author, book.Title, TimeSpan.FromMinutes(1), ct);

            if (!repeated)
            {
                toPersist.Add(new SearchHistory(
                    Id: 0,
                    Author: request.Author,
                    Title: book.Title,
                    PublicationYear: book.PublicationYear,
                    Publisher: book.Publisher,
                    SearchedAt: now
                ));
            }
        }

        if (toPersist.Count > 0)
            await historyRepository.AddRangeAsync(toPersist, ct);

        return result;
    }
}