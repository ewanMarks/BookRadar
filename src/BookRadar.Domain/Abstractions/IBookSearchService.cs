using BookRadar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadar.Domain.Abstractions;

public interface IBookSearchService
{
    Task<IReadOnlyList<Book>> SearchByAuthorAsync(string author, CancellationToken ct = default);
}
