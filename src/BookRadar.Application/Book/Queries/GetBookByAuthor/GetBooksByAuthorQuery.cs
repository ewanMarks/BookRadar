using BookRadar.Application.Dtos.Book;
using MediatR;

namespace BookRadar.Application.Book.Queries.GetBookByAuthor;

public sealed record GetBooksByAuthorQuery(string Author) : IRequest<IReadOnlyList<BookDto>>;
