using BookRadar.Application.Book.Queries.GetBookByAuthor;
using BookRadar.Application.History.Queries.GetSearchHistory;
using BookRadar.Web.ViewModels.Book;
using BookRadar.Web.ViewModels.History;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookRadar.Web.Controllers.BookAndHistory;

public sealed class BooksController(IMediator mediator, IMapper mapper) : Controller
{
    [HttpGet]
    public IActionResult Search() => View();

    [HttpPost]
    public async Task<IActionResult> Search(string author, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            ModelState.AddModelError(nameof(author), "Author is required.");
            return View();
        }

        var books = await mediator.Send(new GetBooksByAuthorQuery(author), ct);
        var vm = mapper.Map<IReadOnlyList<BookViewModel>>(books);
        return View("Results", vm);
    }

    [HttpGet]
    public async Task<IActionResult> History(CancellationToken ct)
    {
        var history = await mediator.Send(new GetSearchHistoryQuery(), ct);
        var vm = mapper.Map<IReadOnlyList<SearchHistoryViewModel>>(history);
        return View(vm);
    }
}