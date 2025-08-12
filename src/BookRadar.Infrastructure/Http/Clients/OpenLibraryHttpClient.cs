using BookRadar.Domain.Abstractions;
using BookRadar.Domain.Entities;
using BookRadar.Infrastructure.Http.Models;
using MapsterMapper;
using System.Net.Http.Json;

namespace BookRadar.Infrastructure.Http.Clients;


public sealed class OpenLibraryHttpClient(HttpClient http, IMapper mapper) : IBookSearchService
{
    public async Task<IReadOnlyList<Book>> SearchByAuthorAsync(string author, CancellationToken ct = default)
    {
        var url = $"https://openlibrary.org/search.json?author={Uri.EscapeDataString(author)}";
        var payload = await http.GetFromJsonAsync<OpenLibraryResponse>(url, ct)
                      ?? new OpenLibraryResponse();

        // mapear docs -> Domain.Book
        var mapped = mapper.Map<IReadOnlyList<Book>>(payload.Docs);
        return mapped;
    }
}
